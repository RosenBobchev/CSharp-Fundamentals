using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Miner
{
    private string id;

    protected Miner(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}

