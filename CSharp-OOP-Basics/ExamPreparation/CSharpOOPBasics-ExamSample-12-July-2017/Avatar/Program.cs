﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        var interpreter = new Engine(new NationsBuilder());
        interpreter.Execute();
    }
}

