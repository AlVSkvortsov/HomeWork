﻿using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;
using System;

namespace Calculator.Processing.InputDataAnalyzers
{
    public class SimpleInputDataAnalyzer<TResultInfo> : InputDataAnalyzer<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        public SimpleInputDataAnalyzer(TResultInfo resultInfo) : base(resultInfo) { }
        public Calculation Analysis(double firstValue, double secondValue, Func<double, double, double> functions)
        {
            return new Calculation(new Calculation(firstValue), new Calculation(secondValue), functions);
        }
    }
}

