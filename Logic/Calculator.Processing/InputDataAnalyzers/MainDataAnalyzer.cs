using Calculator.Core;
using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using Calculator.Processing.Operations;
using Calculator.Processing.Validators;
using System;
using System.Collections.Generic;

namespace Calculator.Processing.InputDataAnalyzers
{
    class MainDataAnalyzer<TResultInfo> : InputDataAnalyzer<TResultInfo>
         where TResultInfo : class, IResultOutput
    {
        public MainDataAnalyzer(TResultInfo resultInfo) : base(resultInfo) { }
        public override ICalculation Analysis(string problem)
        {
            try
            {
                // ((1+2)+3)+(4+((2/1)+3))
                var operations = BuildOperators();

                Calculation calculation1 = new Calculation(2d, 1d, operations["division"]);
                Calculation calculation2 = new Calculation(calculation1, 3d, operations["sum"]);
                Calculation calculation3 = new Calculation(4d, calculation2, operations["sum"]);
                Calculation calculation4 = new Calculation(calculation2, calculation3, operations["sum"]);

                return calculation4;
            }
            catch (Exception ex)
            {
                ResultInfo.Error(new Exception($"Error in {this.GetType().Name}: {ex.Message}", ex));
                return null;
            }
        }

        private Dictionary<string, Func<object, object, double>> BuildOperators() 
        {
            List<IValidator> divValidators = new List<IValidator>
            {
                new NonnegativeValidator()
            };

            return new Dictionary<string, Func<object, object, double>>
            {
                ["division"] = new DivisionOperation(ResultInfo, divValidators).Execute,
                ["multiplication"] = new MultiplicationOperation(ResultInfo).Execute,
                ["subtraction"] = new SubtractionOperation(ResultInfo).Execute,
                ["sum"] = new SumOperation(ResultInfo).Execute
            };
        }

    //private static SelectOperation()
    //{

    //}
    }
}
