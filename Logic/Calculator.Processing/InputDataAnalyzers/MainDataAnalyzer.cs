using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;
using Calculator.Data;
using Calculator.Processing.Operations;
using System;

namespace Calculator.Processing.InputDataAnalyzers
{
    class MainDataAnalyzer<TResultInfo> : InputDataAnalyzer<TResultInfo>
         where TResultInfo : class, IResultOutput
    {
        public override Calculation Analysis(string example, TResultInfo resultInfo)
        {
            Calculation calculation = new Calculation(5d, 5d, new SumOperation(resultInfo).Execute);


            throw new NotImplementedException();
        }
    }
}
