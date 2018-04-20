﻿using System;
using System.Collections.Generic;
using System.Linq;

public class ProviderController : IProviderController
{
    private List<IProvider> providers;
    private IEnergyRepository energyRepository;
    private IProviderFactory factory;

    public ProviderController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.providers = new List<IProvider>();
        this.factory = new ProviderFactory();
    }

    public IReadOnlyCollection<IEntity> Entities => this.providers.AsReadOnly();

    public double TotalEnergyProduced { get; set; }
    
    public string Register(IList<string> arguments)
    {
        string id = arguments[1];
        var provider = this.factory.GenerateProvider(arguments);
        this.providers.Add(provider);

        return string.Format(Constants.SuccessfullRegistration, 
            provider.GetType().Name);
    }

    public string Produce()
    {
        double energyProduced = this.providers.Select(n => n.Produce()).Sum();
        this.energyRepository.StoreEnergy(energyProduced);
        this.TotalEnergyProduced += energyProduced;
        List<IProvider> reminder = new List<IProvider>();

        foreach (var provider in this.providers)
        {
            try
            {
                provider.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(provider);
            }
        }

        foreach (var entity in reminder)
        {
            this.providers.Remove(entity);
        }

        return string.Format(Constants.EnergyProducedToday, energyProduced);
    }

    public string Repair(double val)
    {
        foreach (var provider in this.providers)
        {
            provider.Repair(val);
        }

        return string.Format(Constants.ProvidersRepaired, val);
    }
}