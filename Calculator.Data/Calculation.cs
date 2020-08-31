using System;

namespace Calculator.Data
{
    public class Calculation
    {
        public object _firstCalc;
        public object _secondCalc;
        private Func<object, object, double> _functions { get; set; }

        public Calculation(object firstValue, object secondValue, Func<object, object, double> functions)
        {
            if ((firstValue is Calculation || firstValue is double)
                && (secondValue is Calculation || secondValue is double))
            {
                _firstCalc = firstValue;
                _secondCalc = secondValue;
                _functions = functions;
            }
            else
            {
                throw new ArgumentException("Invalid type of input parameters, 'double' or 'Calculation' must be used");
            }
        }

        public double Execute()
        {
            return _functions(_firstCalc, _secondCalc);
        }
    }
}
