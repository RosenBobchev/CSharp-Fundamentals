using System;
using System.Collections.Generic;
using System.Text;

public class Database
{
    private int[] elements;

    public Database(params int[] input)
    {
        this.elements = new int[16];

        for (int i = 0; i < input.Length; i++)
        {
            this.Add(input[i]);
        }

        this.Count = input.Length;
    }

    public int Count { get; set; }

    public void Add(int element)
    {
        if (this.Count == 16)
        {
            throw new InvalidOperationException("The Array Is Full!");
        }
        else
        {
            this.elements[this.Count] = element;
            this.Count++;
        }
    }

    public void Remove()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The Array Is Empty!");
        }
        else
        {
            this.elements[this.Count - 1] = 0;
            this.Count--;
        }
    }

    public int[] Fetch()
    {
        int[] arrayToReturn = new int[this.Count];
        Array.Copy(this.elements, arrayToReturn, this.Count);

        return arrayToReturn;
    }
}