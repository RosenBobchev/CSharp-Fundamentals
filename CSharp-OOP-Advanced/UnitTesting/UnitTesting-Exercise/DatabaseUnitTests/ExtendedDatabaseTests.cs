using NUnit.Framework;
using System;

public class ExtendedDatabaseTests
{
    private const int Capacity = 16;
    private ExtendedDatabase database;

    [Test]
    public void TestFetchMethod()
    {
        Person person = new Person(1, "Pencho");
        
        this.database = new ExtendedDatabase(person);
        
        Assert.AreEqual(person, this.database.Fetch()[0]);
    }

    [Test]
    public void InitDatabaseWithOneInteger()
    {
        var expectedLength = 1;
        
        this.database = new ExtendedDatabase(new Person(1, "Pencho"));

        Assert.AreEqual(expectedLength, this.database.Fetch().Length);
    }

    [Test]
    public void InitDatabaseWithMaxCapacity()
    {
        Person[] array = new Person[Capacity];
        for (int i = 0; i < Capacity; i++)
        {
            array[i] = new Person(i, "Pencho" + i);
        }
        
        this.database = new ExtendedDatabase(array);
        
        Assert.AreEqual(Capacity, this.database.Fetch().Length);
    }

    [Test]
    public void InitDatabaseWithMoreIntegersThanCapacity()
    {
        Person[] array = new Person[17];
        for (int i = 0; i < 17; i++)
        {
            array[i] = new Person(i, "Pencho" + i);
        }
        
        Assert.Throws<InvalidOperationException>(() => this.database = new ExtendedDatabase(array));
    }

    [Test]
    public void AddOneElementInDatabase()
    {
        Person element = new Person(1, "Pencho" + 1);
        int expected = 2;
        this.database = new ExtendedDatabase(element);
        
        this.database.Add(new Person(2, "Pencho" + 2));
        
        Assert.AreEqual(expected, this.database.Fetch().Length);
    }

    [Test]
    public void AddElementWithSameUsernameInDatabase()
    {
        Person element = new Person(1, "Pencho");
        this.database = new ExtendedDatabase(element);
        
        Person newElementWithSameUsername = new Person(2, "Pencho");
        
        Assert.Throws<InvalidOperationException>(() => this.database.Add(newElementWithSameUsername));
    }

    [Test]
    public void AddElementWithSameIdInDatabase()
    {
        Person element = new Person(1, "Pencho");
        this.database = new ExtendedDatabase(element);
        
        Person newElementWithSameUsername = new Person(1, "Pencho1");
        
        Assert.Throws<InvalidOperationException>(() => this.database.Add(newElementWithSameUsername));
    }

    [Test]
    public void AddToNextFreeCell()
    {
        Person element = new Person(1, "Pencho");
        Person elementToAdd = new Person(2, "Pencho1"); ;
        this.database = new ExtendedDatabase(element);
        
        this.database.Add(elementToAdd);
        
        Assert.AreEqual(new Person[] { element, elementToAdd }, this.database.Fetch());
    }

    [Test]
    public void AddElementsEqualToCapacity()
    {
        Person initElement = new Person(0, "Pencho");
        this.database = new ExtendedDatabase(initElement);
        
        for (int i = 1; i < Capacity; i++)
        {
            this.database.Add(new Person(i, "Pencho" + i));
        }
        
        Assert.AreEqual(16, this.database.Fetch().Length);
    }

    [Test]
    public void AddMoreThanCapacity()
    {
        Person initElement = new Person(0, "Pencho");
        this.database = new ExtendedDatabase(initElement);
        
        for (int i = 1; i < Capacity; i++)
        {
            this.database.Add(new Person(i, "Pencho" + i));
        }

        Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Pencho" + 17)));
    }

    [Test]
    public void RemoveOneElementFromDatabaseWithMoreThanOne()
    {
        Person first = new Person(1, "Pencho");
        Person second = new Person(2, "Pencho1"); ;
        this.database = new ExtendedDatabase(first, second);
        
        this.database.Remove();
        
        Assert.AreEqual(new Person[] { first }, this.database.Fetch());
    }

    [Test]
    public void FindElementById()
    {
        Person expected = new Person(1, "Pencho");
        this.database = new ExtendedDatabase(expected);
        
        Person result = this.database.FindById(1);
        
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void FindElementByNegativeId()
    {
        Person expected = new Person(1, "Pencho");
        this.database = new ExtendedDatabase(expected);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
    }

    [Test]
    public void FindElementByUsername()
    {
        Person expected = new Person(1, "Pencho");
        this.database = new ExtendedDatabase(expected);
        
        Person result = this.database.FindByUsername("Pencho");
        
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void FindElementByUsernameInDatabaseWithoutThatElement()
    {
        Person expected = new Person(1, "Pencho");
        this.database = new ExtendedDatabase(expected);
        
        Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Gradimarin"));
    }
}