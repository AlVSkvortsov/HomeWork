using Calculator.Core.Operations;
using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using System.Collections.Generic;

namespace Calculator.Processing.Operations
{
    public class MultiplicationOperation : Operation
    {
        public MultiplicationOperation(IResultOutput outputManager) : base(outputManager) { }
        public MultiplicationOperation(IResultOutput outputManager, IReadOnlyList<IValidator> validators) : base(outputManager, validators) { }
        protected override double DoExecute(double firstArgument, double secondArgument)
        {
            return firstArgument * secondArgument;
        }
    }
}
