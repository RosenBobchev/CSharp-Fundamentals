using NUnit.Framework;
using System;

public class AxeTests
{
    private const int Attack = 10;
    private const int Durability = 10;
    private const int ExpectedDurability = 9;
    Dummy dummy = new Dummy(10, 10);

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(Attack, Durability);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(ExpectedDurability), "Axe Durability doesn't change after attack");
    }

    [Test]
    public void AxeIsBrokenAfterAttack()
    {
        Axe axe = new Axe(Attack, 0);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}