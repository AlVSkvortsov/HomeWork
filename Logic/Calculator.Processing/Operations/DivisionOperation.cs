using Calculator.Core.Operations;
using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using Calculator.Processing.Validators;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Processing.Operations
{
    public class DivisionOperation : Operation
    {
        public DivisionOperation(IResultOutput resultOutput) : base(resultOutput, new List<IValidator> { new DivisionByZeroValidator() }) {}

        public DivisionOperation(IResultOutput resultOutput, List<IValidator> validators) : base(resultOutput, validators) 
        {
            if (validators.FirstOrDefault(v => v is DivisionByZeroValidator) != null)
            {
                validators.Add(new DivisionByZeroValidator());
            }
        }
        protected override double DoExecute(double firstArgument, double secondArgument)
        {
            return firstArgument / secondArgument;
        }
    }
}
