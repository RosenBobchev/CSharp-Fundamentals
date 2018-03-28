using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Stack<string> stack = new Stack<string>();
        string commandInput = string.Empty;

        while ((commandInput = Console.ReadLine()) != "END")
        {
            List<string> commandArgs = commandInput.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = commandArgs[0];

            switch (command)
            {
                case "Push":
                    stack.Push(commandArgs.Skip(1).ToList());
                    break;
                case "Pop":
                    stack.Pop();
                    break;
                    
            }
        }

        if (stack.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}

