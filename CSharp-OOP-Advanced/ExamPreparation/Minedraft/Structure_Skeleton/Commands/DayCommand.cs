using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string produceEnergy = this.providerController.Produce();
        string produceOreOutput = this.harvesterController.Produce();
        
        var sb = new StringBuilder();
        sb.AppendLine(produceEnergy);
        sb.Append(produceOreOutput);

        return sb.ToString().Trim();
    }
}