using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authours)
    {
        this.Title = title;
        this.Year = year;
        this.Authours = authours;
    }

    public string Title { get; set; }

    public int Year { get; set; }

    public IReadOnlyList<string> Authours { get; set; }

    public int CompareTo(Book other)
    {
        int result = this.Year.CompareTo(other.Year);

        if (result == 0)
        {
            result = this.Title.CompareTo(other.Title);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}

