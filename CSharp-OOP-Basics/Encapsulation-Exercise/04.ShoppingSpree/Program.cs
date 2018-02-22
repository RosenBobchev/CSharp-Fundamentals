using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var customers = new List<Person>();
        var productsInShop = new List<Product>();

        string[] people = Console.ReadLine().Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
        string[] productsForBuying = Console.ReadLine().Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            GetInfo(customers, productsInShop, people, productsForBuying);

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string buyer = tokens[0];
                string productToBuy = tokens[1];

                var currentBuyer = customers.FirstOrDefault(p => p.Name == buyer);
                var currentProduct = productsInShop.FirstOrDefault(p => p.Name == productToBuy);

                BuyProduct(currentBuyer, currentProduct);
            }

            PrintResult(customers);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintResult(List<Person> customers)
    {
        foreach (var person in customers)
        {
            Console.Write($"{person.Name} - ");

            if (person.Products.Count == 0)
            {
                Console.Write($"Nothing bought");
            }
            else
            {
                Console.Write(string.Join(", ", person.Products.Select(p => p.Name)));
            }

            Console.WriteLine();
        }
    }

    private static void BuyProduct(Person currentBuyer, Product currentProduct)
    {
        if (currentBuyer.Money < currentProduct.Price)
        {
            Console.WriteLine($"{currentBuyer.Name} can't afford {currentProduct.Name}");
        }
        else
        {
            currentBuyer.Products.Add(currentProduct);
            currentBuyer.Money -= currentProduct.Price;
            Console.WriteLine($"{currentBuyer.Name} bought {currentProduct.Name}");
        }
    }

    private static void GetInfo(List<Person> customers, List<Product> productsInShop, string[] people, string[] productsForBuying)
    {
        for (int i = 0; i < people.Length; i += 2)
        {
            var person = new Person(people[i], decimal.Parse(people[i + 1]));
            customers.Add(person);
        }

        for (int i = 0; i < productsForBuying.Length; i += 2)
        {
            var products = new Product(productsForBuying[i], decimal.Parse(productsForBuying[i + 1]));
            productsInShop.Add(products);
        }
    }
}

