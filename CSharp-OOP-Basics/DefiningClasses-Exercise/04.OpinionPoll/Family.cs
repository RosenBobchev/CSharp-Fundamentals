using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Family
{
    public List<Person> family;
    
    public Family()
    {
        family = new List<Person>();
    }
    
    public List<Person> GetOverThirty()
    {
        return family.Where(x => x.Age > 30).ToList();
    }
}
