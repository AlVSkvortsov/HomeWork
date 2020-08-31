using Calculator.Core.ResultOutput;
using Calculator.Data;
using System;

namespace Calculator.Core.InputDataAnalyzers
{
    public class InputDataAnalyzer<TResultInfo> : IInputDataAnalyzer<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        public virtual Calculation Analysis(string example, TResultInfo resultInfo)
        {
            throw new NotImplementedException();
        }
    }
}
