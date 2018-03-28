using System;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>
{
    private List<T> elements;
    private int currentIndex = 0;

    public ListyIterator()
    {
        this.elements = new List<T>();
    }

    public bool Move()
    {
        currentIndex++;
        if (currentIndex >= elements.Count)
        {
            currentIndex--;
            return false;
        }

        return true;
    }

    public bool HasNext()
    {
        if (currentIndex <= elements.Count - 1)
        {
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (elements.Count <= 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        else
        {
            Console.WriteLine(elements[currentIndex]);
        }
    }

    public void Create(List<T> input)
    {
        elements.AddRange(input);
    }
}

