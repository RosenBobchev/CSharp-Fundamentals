using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
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

    public void Add(T element) => data.Add(element);

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = this.data[firstIndex];
        data[firstIndex] = data[secondIndex];
        data[secondIndex] = firstElement;
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
