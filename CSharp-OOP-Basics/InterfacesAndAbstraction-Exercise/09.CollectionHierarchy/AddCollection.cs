using System;
using System.Collections.Generic;
using System.Text;

public class AddCollection : Collection
{
    public AddCollection()
        : base()
    {
    }

    public override void Add(string element)
    {
        base.elements.AddLast(element);
        base.addIndexes.Append(base.count++ + " ");
    }
}

