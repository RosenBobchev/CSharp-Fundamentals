public class Gun : Ammunition
{
    public const double ConstWeight = 1.4;

    public Gun(string name)
        : base(name, ConstWeight)
    {
    }
}