using Calculator.Core.Validators;
using System;

namespace Calculator.Processing.Validators
{
    class DivisionByZeroValidator : IValidator
    {
        public string Id => throw new NotImplementedException();

        public bool IsValid(double first, double second)
        {
            return second != 0;
        }
    }
}
