using Calculator.Core.ResultOutput;
using System;

namespace Calculator.Core.InputDataAnalyzers
{
    public abstract class InputDataAnalyzer<TResultOutput> : IInputDataAnalyzer<TResultOutput>
        where TResultOutput : class, IResultOutput
    {
        protected TResultOutput ResultOutput { get; }
        public InputDataAnalyzer(TResultOutput resultOutput) => ResultOutput = resultOutput;

        public virtual ICalculation Analysis(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
