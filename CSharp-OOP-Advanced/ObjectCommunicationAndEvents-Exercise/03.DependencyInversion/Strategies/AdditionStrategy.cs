public class AdditionStrategy : ICalculator
{
    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return firstOperand + secondOperand;
    }
}