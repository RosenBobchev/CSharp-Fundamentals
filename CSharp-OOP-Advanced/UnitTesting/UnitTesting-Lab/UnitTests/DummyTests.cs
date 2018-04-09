using NUnit.Framework;

public class DummyTests
{
    private const int Experience = 10;
    private const int Health = 5;
    private const int ExpectedHealth = 4;
    Axe axe = new Axe(1, 10);

    [Test]
    public void DummyTakesDamageAfterAttack()
    {
        Dummy dummy = new Dummy(Health, Experience);

        dummy.TakeAttack(axe.AttackPoints);

        Assert.That(dummy.Health, Is.EqualTo(ExpectedHealth));
    }

    [Test]
    public void DummyDiesAfterAttack()
    {
        Dummy dummy = new Dummy(0, Experience);

        Assert.That(() => dummy.TakeAttack(axe.AttackPoints),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        Dummy dummy = new Dummy(0, Experience);
        
        Assert.That(dummy.GiveExperience(), Is.EqualTo(Experience));
    }

    [Test]
    public void AliveDummyCannotGiveXP()
    {
        Dummy dummy = new Dummy(Health, Experience);

        dummy.TakeAttack(axe.AttackPoints);

        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}