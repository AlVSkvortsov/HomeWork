using Calculator.Core.Operations;
using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using System.Collections.Generic;

namespace Calculator.Processing.Operations
{
    public class MultiplicationOperation : Operation
    {
        public MultiplicationOperation(IResultOutput resultOutput) : base(resultOutput) { }
        public MultiplicationOperation(IResultOutput resultOutput, IReadOnlyList<IValidator> validators) : base(resultOutput, validators) { }
        protected override double DoExecute(double firstArgument, double secondArgument)
        {
            return firstArgument * secondArgument;
        }
    }
}
