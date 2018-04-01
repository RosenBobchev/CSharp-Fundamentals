using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        Type commandType = assembly.GetTypes()
            .FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

        if (commandType == null)
        {
            throw new ArgumentException("Invalid command!");
        }

        if (!typeof(IExecutable).IsAssignableFrom(commandType))
        {
            throw new ArgumentException($"{commandType} Is Not A Command!");
        }

        FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

        object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

        object[] constructor = new object[] { data }.Concat(injectArgs).ToArray();

        IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constructor);

        return instance;
    }
}

