using System;
using System.Collections.Generic;
using System.Text;

public class Parents
{
    private string parentName;
    private string parentBirthday;

    public Parents(string parentName, string parentBirthday)
    {
        this.ParentName = parentName;
        this.ParentBirthday = parentBirthday;
    }

    public string ParentName
    {
        get { return parentName; }
        set { parentName = value; }
    }

        public string ParentBirthday
    {
        get { return parentBirthday; }
        set { parentBirthday = value; }
    }

}

