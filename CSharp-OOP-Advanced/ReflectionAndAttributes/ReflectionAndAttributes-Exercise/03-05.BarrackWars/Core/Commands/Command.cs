using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command : IExecutable
{
    private string[] data;

    protected Command(string[] data)
    {
        this.Data = data;
    }

    protected string[] Data
    {
        get { return data; }
        private set { data = value; }
    }
   
    public abstract string Execute();
}
