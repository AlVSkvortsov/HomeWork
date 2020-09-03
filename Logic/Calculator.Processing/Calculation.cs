using Calculator.Core;
using System;

namespace Calculator.Processing
{
    public class Calculation : ICalculation
    {
        private bool _isNegative;
        private bool _isExpression;
        private double _value;
        private double _firstCalc;
        private double _secondCalc;
        private Func<double, double, double> _functions { get; set; }

        public Calculation(double value) => _value = value;
        public Calculation(Calculation firstValue, Calculation secondValue, Func<double, double, double> functions)
        {
            _isExpression = true;
            _firstCalc = firstValue.Execute();
            _secondCalc = secondValue.Execute();
            _functions = functions;
        }

        public Calculation IsNegative(bool isNegative)
        {
            _isNegative = isNegative;
            return this;
        }

        public double Execute()
        {
            double result = (_isExpression) ? _functions(_firstCalc, _secondCalc) : _value;
            return (_isNegative) ? -result : result;
        }
    }
}
