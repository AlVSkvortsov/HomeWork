using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;

namespace Calculator.Core.Calculators
{
    public interface ICalculator<TResultInfo>
        where TResultInfo : IResultOutput
    {
        string DisplayName { get; }
        
        void Calculation();
    }
}
