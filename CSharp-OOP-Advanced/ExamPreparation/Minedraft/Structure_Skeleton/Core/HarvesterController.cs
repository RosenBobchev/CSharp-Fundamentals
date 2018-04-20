using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private IHarvesterFactory factory;
    private IEnergyRepository energyRepository;
    private string mode;
    private List<IHarvester> allHarvesters;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.factory = new HarvesterFactory();
        this.allHarvesters = new List<IHarvester>();
        this.mode = "Full";
    }

    public string Mode => mode;

    public IReadOnlyCollection<IEntity> Entities => this.allHarvesters.AsReadOnly();

    public double OreProduced { get; set; }

    public string ChangeMode(string modeToChange)
    {
        this.mode = modeToChange;

        foreach (var harvester in allHarvesters)
        {
            harvester.Broke();
        }

        allHarvesters = allHarvesters.Where(h => h.Durability >= 0).ToList();
        return $"Mode changed to {modeToChange}!";
    }

    public string Produce()
    {
        //calculate needed energy
        double neededEnergy = 0;
        foreach (var harvester in this.allHarvesters)
        {
            if (this.Mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.Mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.Mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.EnergyStored >= neededEnergy)
        {
            //mine
            this.energyRepository.TakeEnergy(neededEnergy);
            foreach (var harvester in this.allHarvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        //take the mode in mind
        if (this.Mode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.Mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string Register(IList<string> args)
    {
        string id = args[1];
        var harvester = this.factory.GenerateHarvester(args);
        this.allHarvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}