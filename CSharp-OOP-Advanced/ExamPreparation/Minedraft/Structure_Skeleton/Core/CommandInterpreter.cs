using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    private IEnergyRepository energyRepository;

    public CommandInterpreter()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
        this.harvesterController = new HarvesterController(energyRepository);
    }

    IHarvesterController ICommandInterpreter.HarvesterController => this.harvesterController;

    IProviderController ICommandInterpreter.ProviderController => this.providerController;

    public string ProcessCommand(IList<string> data)
    {
        var commandName = data[0] + "Command";
        Type commandType = Type.GetType(commandName);

        ParameterInfo[] parameterInfo = commandType.GetConstructors().First().GetParameters();
        object[] ctorParams = new object[parameterInfo.Length];

        for (int i = 0; i < ctorParams.Length; i++)
        {
            if (parameterInfo[i].Name == "harvesterController")
            {
                ctorParams[i] = this.harvesterController;
            }
            else
            {
                if (parameterInfo[i].Name == "providerController")
                {
                    ctorParams[i] = this.providerController;
                }
                else
                {
                    ctorParams[i] = data.Skip(1).ToList();
                }
            }
        }
        
        var command = (ICommand)Activator.CreateInstance(commandType, ctorParams);

        return command.Execute();
    }
}