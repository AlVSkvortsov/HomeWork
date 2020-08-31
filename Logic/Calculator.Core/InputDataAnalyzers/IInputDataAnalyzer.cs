using Calculator.Core.ResultOutput;
using Calculator.Data;

namespace Calculator.Core.InputDataAnalyzers
{
    public interface IInputDataAnalyzer<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        Calculation Analysis(string example, TResultInfo resultInfo);
    }
}
