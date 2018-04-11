using System;
using System.Collections.Generic;
using System.Text;


public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public class Dispatcher
{
    private string name;
    public event NameChangeEventHandler NameChange;


    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            this.OnNameChange(new NameChangeEventArgs(value));
            name = value;
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        if (args != null)
        {
            this.NameChange(this, args);
        }
    }
}