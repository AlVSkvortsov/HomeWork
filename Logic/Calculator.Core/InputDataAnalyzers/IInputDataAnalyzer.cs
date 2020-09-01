using Calculator.Core.ResultOutput;


namespace Calculator.Core.InputDataAnalyzers
{
    public interface IInputDataAnalyzer<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        ICalculation Analysis(string problem);
    }
}
