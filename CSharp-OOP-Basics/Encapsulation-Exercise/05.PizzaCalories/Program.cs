using System;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string pizzaName = pizzaInput[1];
            Pizza pizza = new Pizza(pizzaName);

            Dough dough = CreateDough();
            pizza.SetDough(dough);

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                CreateTopping(pizza, command);
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Dough CreateDough()
    {
        string[] doughInput = Console.ReadLine().Split();
        string flourType = doughInput[1];
        string bakingTechnique = doughInput[2];
        double doughWeight = double.Parse(doughInput[3]);
        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
        return dough;
    }

    private static void CreateTopping(Pizza pizza, string command)
    {
        string[] toppingInfo = command.Split();
        string toppingType = toppingInfo[1];
        double toppingWeight = double.Parse(toppingInfo[2]);

        Topping topping = new Topping(toppingType, toppingWeight);
        pizza.AddTopping(topping);
    }
}

