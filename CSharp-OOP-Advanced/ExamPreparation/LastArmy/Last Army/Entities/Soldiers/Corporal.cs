using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallMultiplier = 2.5;

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(Helmet),
            nameof(Knife),
        };

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallMultiplier;
}