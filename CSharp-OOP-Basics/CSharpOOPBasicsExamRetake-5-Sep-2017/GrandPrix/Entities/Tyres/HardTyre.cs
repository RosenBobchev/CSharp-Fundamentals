using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HardTyre : Tyre
{
    private const string HARDTYRENAME = "Hard";

    public HardTyre(double hardness)
        : base(hardness)
    {
    }

    public override string Name => HARDTYRENAME;
}

