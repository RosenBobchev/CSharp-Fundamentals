using System;
using System.Collections.Generic;
using System.Text;

public abstract class Collection : IAddable
{
    protected int count;
    protected LinkedList<string> elements;
    protected StringBuilder addIndexes;

    public Collection()
    {
        this.count = 0;
        this.elements = new LinkedList<string>();
        this.addIndexes = new StringBuilder();
    }

    public string AddIndexes
    {
        get
        {
            return this.addIndexes.ToString().Trim();
        }
    }
    
    public abstract void Add(string element);
}

