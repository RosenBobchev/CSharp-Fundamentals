using System;
using System.Linq;

public class Engine
{
    private CommandInterpreter commandInterpreter;
    private Reader reader;
    private Writer writer;

    public Engine()
    {
        this.commandInterpreter = new CommandInterpreter();
        this.reader = new Reader();
        this.writer = new Writer();
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine();
            var data = input.Split().ToList();

            writer.WriteLine(commandInterpreter.ProcessCommand(data));

            if (input == "Shutdown")
            {
                Environment.Exit(0);
            }
        }
    }
}