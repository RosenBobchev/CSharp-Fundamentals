using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ExtendedDatabase
{
    private const int InitCapacity = 16;
    private Person[] people;
    private int currentIndex;

    public ExtendedDatabase()
    {
        this.people = new Person[InitCapacity];
        this.currentIndex = 0;
    }

    public ExtendedDatabase(params Person[] people)
        : this()
    {
        this.AddRange(people);
    }

    public void AddRange(Person[] people)
    {
        if (people.Length > 16)
        {
            throw new InvalidOperationException("Array Capacity Is Full!");
        }

        foreach (var person in people)
        {
            this.Add(person);
        }
    }

    public void Add(Person person)
    {
        if (this.currentIndex == InitCapacity)
        {
            throw new InvalidOperationException("Array Capacity Is Full!");
        }

        if (this.people.Any(p => p != null && p.Username == person.Username || p != null && p.Id == person.Id))
        {
            throw new InvalidOperationException("Already Have That Person!");
        }

        this.people[this.currentIndex] = person;
        this.currentIndex++;
    }

    public void Remove()
    {
        this.currentIndex--;
        if (this.currentIndex <= 0)
        {
            throw new InvalidOperationException("Database Is Empty!");
        }

        this.people[this.currentIndex] = default(Person);
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("Negative Id!");
        }

        if (!this.people.Any(p => p != null && p.Id == id))
        {
            throw new InvalidOperationException("No Person Found With That Id!");
        }

        Person person = this.people.First(p => p.Id == id);

        return person;
    }

    public Person FindByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException("Username parameter is null!");
        }

        if (!this.people.Any(p => p != null && p.Username == username))
        {
            throw new InvalidOperationException("No person with this username!");
        }

        Person person = this.people.First(p => p.Username == username);

        return person;
    }

    public Person[] Fetch()
    {
        Person[] subarray = this.people.Skip(0).Take(this.currentIndex).ToArray();

        return subarray;
    }
}