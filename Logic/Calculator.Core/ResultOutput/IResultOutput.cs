using Calculator.Core.Validators;
using System;
using System.Collections.Generic;

namespace Calculator.Core.ResultOutput
{
    public interface IResultOutput
    {
        double ResaltValue { get; set; }
        List<string> ErrorValidate { get; set; }
        void Error<TException>(TException exception)
            where TException : Exception;
    }
}
