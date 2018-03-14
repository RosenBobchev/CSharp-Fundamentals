using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre CreateTyre(List<string> args)
    {
        if (args[0] == "Ultrasoft")
        {
            var grip = double.Parse(args[2]);
            return new UltrasoftTyre(double.Parse(args[1]), grip);
        }

        return new HardTyre(double.Parse(args[1]));
    }
}
