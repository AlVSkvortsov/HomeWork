using Calculator.Processing.Calculators;
using Calculator.Processing.ResultOutput;
using Calculator.Core.ResultOutput;

namespace Calculator
{
    public static class Calculators
    {
        public static IResultOutput SimpleCalculator(double firstArgument, double secondArgument, char mathOperator)
        {
            IResultOutput result = new DefaultResultOutput();

            new SimpleCalculator<IResultOutput>(firstArgument, secondArgument, mathOperator, result).Calculation();

            return result;
        }

        public static IResultOutput MainCalculator(string expression)
        {
            IResultOutput result = new DefaultResultOutput();

            new MainCalculator<IResultOutput>(expression, result).Calculation();

            return result;
        }
    }
}
