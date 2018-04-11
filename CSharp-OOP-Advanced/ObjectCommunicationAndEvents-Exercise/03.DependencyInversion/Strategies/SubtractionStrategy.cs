public class SubtractionStrategy : ICalculator
{
     public int PerformCalculation(int firstOperand, int secondOperand)
     {
         return firstOperand - secondOperand;
     }
 }