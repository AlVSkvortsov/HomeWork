using Calculator.Core.Validators;

namespace Calculator.Processing.Validators
{
    class NonnegativeValidator : Validator
    {
        public override bool IsValid(double first, double second)
        {
            return first >= 0 && second >= 0;
        }
    }
}
