using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    where T : IComparable<T>
{
    private T value;
    private List<T> data;

    public Box()
    {
        this.Value = value;
        this.data = new List<T>();
    }

    public T Value
    {
        get { return this.value; }
        private set { this.value = value; }
    }

    public List<T> Data => this.data;

    public void Add(T element) => data.Add(element);

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = this.data[firstIndex];
        data[firstIndex] = data[secondIndex];
        data[secondIndex] = firstElement;
    }

    public int Compare(List<T> elements, T element)
    {
        int counter = 0;

        foreach (var item in elements)
        {
            if (element.CompareTo(item) < 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var element in this.data)
        {
            sb.AppendLine($"{element.GetType().FullName}: {element}");
        }

        return sb.ToString().Trim();
    }
}
