using System;
using System.Collections.Generic;
using System.Text;

public class NameComparer : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        char firstPersonChar = Char.ToLower(firstPerson.Name[0]);
        char secondPersonChar = Char.ToLower(secondPerson.Name[0]);
        int result = 0;

        if (firstPerson.Name.Length.CompareTo(secondPerson.Name.Length) == 0)
        {
            result = firstPersonChar.CompareTo(secondPersonChar);
        }
        else
        {
            result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);
        }

        return result;
    }
}

