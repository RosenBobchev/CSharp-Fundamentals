using System;
using System.Collections.Generic;
using System.Text;

public class PriceCalculator
{
    private decimal pricePerDay;
    private int days;
    private Seasons season;
    private Discounts discount;

    public PriceCalculator(string command)
    {
        var splitCommand = command.Split();
        pricePerDay = decimal.Parse(splitCommand[0]);
        days = int.Parse(splitCommand[1]);
        season = Enum.Parse<Seasons>(splitCommand[2]);
        discount = Discounts.None;

        if (splitCommand.Length > 3)
        {
            discount = Enum.Parse<Discounts>(splitCommand[3]);
        }
    }

    public string CalculatePrice()
    {
        var tempTotal = pricePerDay * days * (int)season;
        var discountPercentage = ((decimal)100 - (int)discount) / 100;
        var totalPrice = tempTotal * discountPercentage;
        return totalPrice.ToString("F2");
    }
}

