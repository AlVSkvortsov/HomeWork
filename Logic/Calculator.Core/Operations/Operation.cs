using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using System;
using System.Collections.Generic;

namespace Calculator.Core.Operations
{
    public abstract class Operation : IOperation
    {
        private readonly IResultOutput _resultOutput;
        private readonly IReadOnlyList<IValidator> _validators;
        public virtual string DisplayName => this.GetType().Name;
       
        public Operation(IResultOutput resultOutput) => _resultOutput = resultOutput;
        public Operation(IResultOutput resultOutput, IReadOnlyList<IValidator> validators) : this(resultOutput) => _validators = validators;

        public double Execute(double firstArgument, double secondArgument)
        {
            try
            {
                if (Validate(firstArgument, secondArgument))
                {
                    return DoExecute(firstArgument, secondArgument);
                }
                _outputManager.Error(new Exception("Validation failed"));
            }
            catch (Exception ex)
            {
                _outputManager.Error(ex);
            }
            return 0;
        }

        protected abstract double DoExecute(double firstArgument, double secondArgument);

        private bool Validate(double first, double second)
        {
            if (_validators == null) 
                return true;

            bool result = true;
            foreach (IValidator validator in _validators)
            {
                if (validator.IsValid(first, second))
                {
                    continue;
                }
                if (_outputManager.ErrorValidate == null) _outputManager.ErrorValidate = new List<string>();
                _outputManager.ErrorValidate.Add($"{validator.Id} is not valid");
                result = false;
            }

            return result;
        }
    }
}
