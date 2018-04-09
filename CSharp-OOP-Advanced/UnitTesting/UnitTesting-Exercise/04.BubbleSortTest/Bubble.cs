using System;
using System.Collections.Generic;
using System.Text;

public class Bubble
{
    public void Sort(int[] numbers)
    {
        var swapped = true;

        while (swapped)
        {
            swapped = false;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    var temp = numbers[i - 1];
                    numbers[i - 1] = numbers[i];
                    numbers[i] = temp;
                    swapped = true;
                }
            }
        }
    }
}