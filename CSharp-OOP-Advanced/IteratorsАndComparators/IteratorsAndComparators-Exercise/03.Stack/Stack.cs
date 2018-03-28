using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    private List<T> elements;

    public Stack()
    {
        this.elements = new List<T>();
    }

    public int Count => elements.Count;

    public void Push(List<T> items)
    {
        elements.AddRange(items);
    }

    public void Pop()
    {
        if (elements.Count <= 0)
        {
            Console.WriteLine("No elements");
        }
        else
        {
            var elementToRemove = elements.Count - 1;
            elements.RemoveAt(elementToRemove);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = elements.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
        for (int i = elements.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

