public class Emerald : Gem
{
    private const int AgilityBonus = 4;
    private const int StrengthBonus = 1;
    private const int VitalityBonus = 9;

    public Emerald(GemClarity clarity)
        : base(clarity, AgilityBonus, StrengthBonus, VitalityBonus)
    {
    }
}
