using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>();
        string commandInput = string.Empty;

        while ((commandInput = Console.ReadLine()) != "END")
        {
            var tokens = commandInput.Split();
            var command = tokens[0];
            var commandArgs = tokens.Skip(1).ToList();

            try
            {
                switch (command)
                {
                    case "Create":
                        listyIterator.Create(commandArgs);
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

