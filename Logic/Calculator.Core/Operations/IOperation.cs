using Calculator.Data;

namespace Calculator.Core.Operations
{
    public interface IOperation
    {
        string DisplayName { get; }
        double Execute(object FirstArgument, object SecondArgument);
    }
}
