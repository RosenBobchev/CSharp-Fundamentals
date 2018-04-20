using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Produced: {this.providerController.TotalEnergyProduced}");
        sb.Append($"Total Mined Plumbus Ore: {this.harvesterController.OreProduced}");

        return sb.ToString();
    }
}