using System;
using System.Linq;
using System.Reflection;

class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IFestivalController festivalController;
    private ISetController setController;
    private IStage stage;

    public Engine(IFestivalController festivalController, ISetController setController)
    {
        this.stage = new Stage();
        this.reader = new Reader();
        this.writer = new Writer();
        this.festivalController = new FestivalController(stage);
        this.setController = new SetController(stage);
    }

    // дайгаз
    public void Run()
    {
        string input = string.Empty;
        while ((input = reader.ReadLine()) != "END") // for job security
        {
            try
            {
                string.Intern(input);

                var result = this.ProcessCommand(input);
                this.writer.WriteLine(result);
            }
            catch (Exception ex) // in case we run out of memory
            {
                this.writer.WriteLine("ERROR: " + ex.Message);
            }
        }

        var end = this.festivalController.ProduceReport();

        this.writer.WriteLine("Results:");
        this.writer.WriteLine(end);
    }

    public string ProcessCommand(string input)
    {
        var tokens = input.Split();

        var command = tokens[0];
        var args = tokens.Skip(1).ToArray();

        if (command == "LetsRock")
        {
            var sets = this.setController.PerformSets();
            return sets;
        }

        var festivalcontrolfunction = this.festivalController.GetType()
            .GetMethods()
            .FirstOrDefault(x => x.Name == command);

        string method = string.Empty;

        try
        {
            method = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { args });
        }
        catch (TargetInvocationException up)
        {
            throw up.InnerException;
        }

        return method;
    }
}