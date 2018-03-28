using System.Collections.Generic;

public class Book
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
}
