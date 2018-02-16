using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        var firstDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);

        DateModifier calculator = new DateModifier();
        calculator.firstDate = firstDate;
        calculator.secondDate = secondDate;

        int result = Math.Abs((int)calculator.CalculateDifference());
        Console.WriteLine(result);
    }
}

