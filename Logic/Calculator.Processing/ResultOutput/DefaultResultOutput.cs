using Calculator.Core.ResultOutput;
using System;
using System.Collections.Generic;

namespace Calculator.Processing.ResultOutput
{
    public class DefaultResultOutput : IResultOutput
    {
        public double ResaltValue { get; set; }
        public List<string> ErrorValidate { get; set; }

        public void Error<TException>(TException exception) where TException : Exception
        {
            throw new NotImplementedException();
        }
    }
}
