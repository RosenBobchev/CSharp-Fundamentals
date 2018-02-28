using System;
using System.Collections.Generic;
using System.Text;

public interface IBuyer
{
    void BuyFood();

    string Name { get; }

    int Age { get; }

    int Food { get; set; }
}

