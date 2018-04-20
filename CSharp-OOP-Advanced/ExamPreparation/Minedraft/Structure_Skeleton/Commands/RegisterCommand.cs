using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string type = this.Arguments[0];
        string result = string.Empty;

        if (type == "Harvester")
        {
            result = harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else
        {
            result = providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}