using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    void Attack(ITarget target);

    int AttackPoints { get; }

    int DurabilityPoints { get; }
}