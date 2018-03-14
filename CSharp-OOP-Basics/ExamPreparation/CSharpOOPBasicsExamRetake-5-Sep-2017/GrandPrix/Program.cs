using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        var raceTower = new RaceTower();
        var engine = new Engine(raceTower);
        engine.Start();
    }
}

