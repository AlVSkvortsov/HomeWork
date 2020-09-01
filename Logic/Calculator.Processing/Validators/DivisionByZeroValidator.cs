﻿using Calculator.Core.Validators;

namespace Calculator.Processing.Validators
{
    class DivisionByZeroValidator : Validator
    {
        public override bool IsValid(double first, double second)
        {
            return second != 0;
        }
    }
}
