using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string title, string author, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Author
    {
        get { return author; }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Author not valid!");
            }

            string[] authorNames = value.Split();

            if (char.IsDigit(authorNames[authorNames.Length - 1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3 || value == null)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:F2}");

        string result = sb.ToString().TrimEnd();
        return result;
    }
}

