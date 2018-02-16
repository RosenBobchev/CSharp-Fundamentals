using System;
using System.Collections.Generic;
using System.Text;

public class Children
{
    private string childName;
    private string childBirthday;

    public Children(string childName, string childBirthday)
    {
        this.ChildName = childName;
        this.ChildBirthday = childBirthday;
    }

    public string ChildName
    {
        get { return childName; }
        set { childName = value; }
    }

    public string ChildBirthday
    {
        get { return childBirthday; }
        set { childBirthday = value; }
    }

}

