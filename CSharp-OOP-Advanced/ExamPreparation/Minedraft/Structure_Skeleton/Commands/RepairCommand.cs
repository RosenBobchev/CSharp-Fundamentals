using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController)
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double value = double.Parse(this.Arguments[0]);
        return this.providerController.Repair(value);
    }
}
