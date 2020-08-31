using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;
using Calculator.Data;
using System;

namespace Calculator.Processing.InputDataAnalyzers
{
    public class SimpleInputDataAnalyzer<TResultInfo> : InputDataAnalyzer<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        public Calculation Analysis(double firstValue, double secondValue, Func<object, object, double> functions, TResultInfo resultInfo)
        {
            return new Calculation(firstValue, secondValue, functions);
        }
    }
}

