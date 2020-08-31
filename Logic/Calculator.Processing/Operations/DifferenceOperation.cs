using Calculator.Core.Operations;
using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using System.Collections.Generic;

namespace Calculator.Processing.Operations
{
    public class DifferenceOperation : Operation
    {
        public DifferenceOperation(IResultOutput outputManager) : base(outputManager) { }
        public DifferenceOperation(IResultOutput outputManager, IReadOnlyList<IValidator> validators) : base(outputManager, validators) { }
        protected override double DoExecute(double firstArgument, double secondArgument)
        {
            return firstArgument - secondArgument;
        }
    }
}
