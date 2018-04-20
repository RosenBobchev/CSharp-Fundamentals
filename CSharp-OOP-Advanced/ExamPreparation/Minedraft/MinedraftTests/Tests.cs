using NUnit.Framework;
using System.Collections.Generic;

public class Tests
{
    private IProviderController providerController;
    private IEnergyRepository energyRepository;

    [SetUp]
    public void TestInit()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ProduceCorrectEnergy()
    {
        providerController.Register(new List<string> { "Solar", "80", "100" });
        providerController.Register(new List<string> { "Solar", "81", "100" });

        providerController.Produce();
        providerController.Produce();

        Assert.That(providerController.TotalEnergyProduced, Is.EqualTo(400));
    }

    [Test]
    public void IsBrokenProviderDeleted()
    {
        providerController.Register(new List<string> { "Pressure", "80", "100" });

        for (int i = 0; i < 8; i++)
        {
            providerController.Produce();
        }

        Assert.That(providerController.Entities.Count, Is.EqualTo(0));
    }
}