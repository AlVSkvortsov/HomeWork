using Calculator.Core.Operations;
using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using System.Collections.Generic;

namespace Calculator.Processing.Operations
{
    public class SumOperation : Operation
    {
        public SumOperation(IResultOutput resultOutput) : base(resultOutput) { }
        public SumOperation(IResultOutput resultOutput, IReadOnlyList<IValidator> validators) : base(resultOutput, validators) { }
        protected override double DoExecute(double firstArgument, double secondArgument)
        {
            return firstArgument + secondArgument;
        }
    }
}
