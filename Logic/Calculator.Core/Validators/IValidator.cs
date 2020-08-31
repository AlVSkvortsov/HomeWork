namespace Calculator.Core.Validators
{
    public interface IValidator
    {
        string Id { get; }
        bool IsValid(double first, double second);
    }
}
