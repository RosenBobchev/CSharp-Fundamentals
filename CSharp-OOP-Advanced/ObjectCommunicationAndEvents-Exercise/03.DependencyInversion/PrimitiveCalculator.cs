using System;
using System.Collections.Generic;
using System.Text;

public class PrimitiveCalculator
{
    private ICalculator strategy;

    public PrimitiveCalculator()
           : this(new AdditionStrategy())
    {
    }

    public PrimitiveCalculator(ICalculator strategy)
    {
        this.ChangeStrategy(strategy);
    }

    public void ChangeStrategy(ICalculator strategy)
    {
        this.strategy = strategy;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        int result = this.strategy.PerformCalculation(firstOperand, secondOperand);

        return result;
    }
}