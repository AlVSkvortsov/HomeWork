using Calculator.Core.Calculators;
using Calculator.Core.ResultOutput;
using Calculator.Processing.InputDataAnalyzers;
using Calculator.Processing.Operations;
using System;

namespace Calculator.Processing.Calculators
{
    public class SimpleCalculator<TResultInfo> : Calculator<TResultInfo>
        where TResultInfo : class, IResultOutput
    {
        private double _firstArgument;
        private double _secondArgument;
        private char _operator;
        private TResultInfo _resultInfo;
        public SimpleCalculator(double firstArgument, double secondArgument, char mathOperator, TResultInfo resultInfo)
        {
            _firstArgument = firstArgument;
            _secondArgument = secondArgument;
            _operator = mathOperator;
            _resultInfo = resultInfo;
        }

        public override void Calculation()
        {
            Func<object, object, double> operation;

            switch (_operator)
            {
                case '+':
                    operation = new SumOperation(_resultInfo).Execute;
                    break;
                case '-':
                    operation = new SubtractionOperation(_resultInfo).Execute;
                    break;
                case '*':
                    operation = new MultiplicationOperation(_resultInfo).Execute;
                    break;
                case '/':
                    operation = new DivisionOperation(_resultInfo).Execute;
                    break;
                default:
                    throw new Exception($"Error: Incorrect operation: {_operator}");
            }

            _resultInfo.ResultValue = new SimpleInputDataAnalyzer<TResultInfo>(_resultInfo).Analysis(_firstArgument, _secondArgument, operation).Execute();
        }
    }
}
