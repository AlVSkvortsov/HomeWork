namespace Calculator.Core.Validators
{
    public abstract class Validator : IValidator
    {
        public virtual string Id => nameof(Validator);
        public abstract bool IsValid(double first, double second);
    }
}
