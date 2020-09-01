using Calculator.Core.ResultOutput;
using System;
using System.Collections.Generic;

namespace Calculator.Processing.ResultOutput
{
    public class DefaultResultOutput : IResultOutput
    {
        public double ResultValue { get; set; }
        public List<string> ErrorValidate { get; set; }
        private string _errorMessage;
        public string ErrorMessage { get { return _errorMessage; } }
        public void Error<TException>(TException exception) where TException : Exception
        {
            _errorMessage = exception.Message;
        }
    }
}
