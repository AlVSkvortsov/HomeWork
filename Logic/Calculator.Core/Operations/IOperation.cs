namespace Calculator.Core.Operations
{
    public interface IOperation
    {
        string DisplayName { get; }
        double Execute(double FirstArgument, double SecondArgument);
    }
}
