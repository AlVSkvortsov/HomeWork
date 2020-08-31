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
        public DivisionOperation(IResultOutput outputManager) : base(outputManager) { }
        public DivisionOperation(IResultOutput outputManager, List<IValidator> validators) : base(outputManager, validators) 
        {
            if (validators.FirstOrDefault(v => v is DivisionByZeroValidator) != null)
            {
                validators.Add(new DivisionByZeroValidator());
            }
        }
        protected override double DoExecute(double firstArgument, double secondArgument)
        {
            return firstArgument - secondArgument;
        }
    }
}
