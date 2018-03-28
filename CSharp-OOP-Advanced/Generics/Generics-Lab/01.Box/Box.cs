using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<T>
{
    private List<T> box;

    public Box()
    {
        this.box = new List<T>();
    }

    public void Add(T item) => this.box.Add(item);

    public int Count => this.box.Count;

    public T Remove()
    {
        var itemToRemove = this.box.Last();
        this.box.RemoveAt(this.box.Count - 1);

        return itemToRemove;
    }
}

