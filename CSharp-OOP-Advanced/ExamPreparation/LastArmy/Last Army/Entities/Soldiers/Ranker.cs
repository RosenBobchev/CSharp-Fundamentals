using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallMultiplier = 1.5;

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(Helmet),
        };

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallMultiplier;
}