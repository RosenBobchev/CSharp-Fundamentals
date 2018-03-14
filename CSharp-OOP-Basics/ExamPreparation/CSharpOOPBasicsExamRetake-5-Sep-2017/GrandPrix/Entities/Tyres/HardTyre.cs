public class HardTyre : Tyre
{
    private const string HARDTYRENAME = "Hard";

    public HardTyre(double hardness)
        : base(hardness)
    {
    }

    public override string Name => HARDTYRENAME;
}

