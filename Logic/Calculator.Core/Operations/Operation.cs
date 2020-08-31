﻿using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using Calculator.Data;
using System;
using System.Collections.Generic;

namespace Calculator.Core.Operations
{
    public abstract class Operation : IOperation
    {
        private readonly IResultOutput _outputManager;
        private readonly IReadOnlyList<IValidator> _validators;
        public virtual string DisplayName => this.GetType().Name;
       
        public Operation(IResultOutput outputManager) => _outputManager = outputManager;
        public Operation(IResultOutput outputManager, IReadOnlyList<IValidator> validators) : this(outputManager) => _validators = validators;

        public double Execute(object firstArgument, object secondArgument)
        {
            var firstCalc = firstArgument as Calculation;
            var secondCalc = secondArgument as Calculation;

            double first = (firstCalc == null) ? (double)firstArgument : firstCalc.Execute();
            double second = (secondCalc == null) ? (double)secondArgument : secondCalc.Execute();

            if (Validate(first, second))
            {
                return DoExecute(first, second);
            }

            throw new Exception("Validation failed");
        }

        protected abstract double DoExecute(double firstArgument, double secondArgument);

        private bool Validate(double first, double second)
        {
            if (_validators == null) 
                return true;

            bool result = true;
            foreach (IValidator validator in _validators)
            {
                if (validator.IsValid(this))
                {
                    continue;
                }
                _outputManager.ErrorValidate.Add($"{validator.Id} is not valid");
                result = false;
            }

            return result;
        }
    }
}