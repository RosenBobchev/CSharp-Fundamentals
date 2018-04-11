using System;

public class StartUp
{
    static void Main(string[] args)
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            if (command == "mode")
            {
                char @operator = tokens[1][0];

                ICalculator strategy = null;

                switch (@operator)
                {
                    case '+':
                        strategy = new AdditionStrategy();
                        break;
                    case '-':
                        strategy = new SubtractionStrategy();
                        break;
                    case '*':
                        strategy = new MultiplicationStrategy();
                        break;
                    case '/':
                        strategy = new DivisionStrategy();
                        break;
                }
                calculator.ChangeStrategy(strategy);

                if (strategy == null)
                {
                    throw new ArgumentException("Invalid mode!");
                }
            }
            else
            {
                int firstOperand = int.Parse(tokens[0]);
                int secondOperand = int.Parse(tokens[1]);

                int result = calculator.PerformCalculation(firstOperand, secondOperand);

                Console.WriteLine(result);
            }
        }
    }
}