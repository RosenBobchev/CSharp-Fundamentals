using System;

namespace _04.HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var priceCalculator = new PriceCalculator(command);
            var totalPrice = priceCalculator.CalculatePrice();

            Console.WriteLine(totalPrice);
        }
    }
}
