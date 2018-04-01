using System;
using Microsoft.Extensions.DependencyInjection;

public class StartUp
{
    static void Main(string[] args)
    {
        IServiceProvider serviceProvider = ConfigureServices();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

        IRunnable engine = new Engine(commandInterpreter);
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<IUnitFactory, UnitFactory>();
        services.AddSingleton<IRepository, UnitRepository>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}

