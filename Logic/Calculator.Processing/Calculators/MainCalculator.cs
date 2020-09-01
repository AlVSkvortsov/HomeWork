using Calculator.Core.Calculators;
using Calculator.Core.ResultOutput;
using Calculator.Processing.InputDataAnalyzers;


namespace Calculator.Processing.Calculators
{
    public class MainCalculator<TResultInfo> : Calculator<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        private TResultInfo _resultInfo;
        private string _problem;
        public MainCalculator(string problem, TResultInfo resultInfo)
        {
            _resultInfo = resultInfo;
            _problem = problem;
        }

        public override void Calculation()
        {
            var calc = new MainDataAnalyzer<TResultInfo>(_resultInfo).Analysis(_problem);
            if (calc != null) calc.Execute();
        }
    }
}
