namespace Calculator.Core.Validators
{
    public abstract class Validator : IValidator
    {
        public virtual string Id => this.GetType().Name;
        public abstract bool IsValid(double first, double second);
    }
}
