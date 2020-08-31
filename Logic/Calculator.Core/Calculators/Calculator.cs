using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;

namespace Calculator.Core.Calculators
{
    public abstract class Calculator<TResultInfo> : ICalculator<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        public virtual string DisplayName => this.GetType().Name;

        public abstract void Calculation();
    }
}
