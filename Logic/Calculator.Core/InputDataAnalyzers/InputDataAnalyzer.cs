using Calculator.Core.ResultOutput;
using System;

namespace Calculator.Core.InputDataAnalyzers
{
    public abstract class InputDataAnalyzer<TResultInfo> : IInputDataAnalyzer<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        private TResultInfo _resultInfo;
        protected TResultInfo ResultInfo { get { return _resultInfo; } }
        public InputDataAnalyzer(TResultInfo resultInfo) => _resultInfo = resultInfo;

        public virtual ICalculation Analysis(string problem)
        {
            throw new NotImplementedException();
        }
    }
}
