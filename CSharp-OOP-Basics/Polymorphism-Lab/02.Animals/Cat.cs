﻿using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Animal
{
    public Cat(string name, string favouriteFood) 
        : base(name, favouriteFood)
    {
    }

    public override string ExplainSelf()
    {
        return base.ExplainSelf() + ' ' + "MEEOW";
    }
}
