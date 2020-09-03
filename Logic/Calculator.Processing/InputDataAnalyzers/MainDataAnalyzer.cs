using Calculator.Core;
using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;
using Calculator.Core.Validators;
using Calculator.Processing.Operations;
using Calculator.Processing.ResultOutput;
using Calculator.Processing.Validators;
using Sprache;
using System;
using System.Collections.Generic;

namespace Calculator.Processing.InputDataAnalyzers
{
    class MainDataAnalyzer<TResultInfo> : InputDataAnalyzer<TResultInfo>
         where TResultInfo : class, IResultOutput
    {
        public MainDataAnalyzer(TResultInfo resultInfo) : base(resultInfo) { }
        public override ICalculation Analysis(string expression)
        {
            try
            {

                Calculation r = expr.Parse(expression);




                //var test = r as Calculation;


                // ((2/1)+3)+(4+((2/1)+3))
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

        enum opType
        {
            add, sub, mul, div, pow
        }

        static Parser<opType> Operator(string op, opType type)
        {
            return Parse.String(op).Token().Return(type);
        }

        static Calculation binaryApply(opType op, object a, object b)
        {
            switch (op)
            {
                case opType.add:
                    return new Calculation(a, b, new SumOperation(new DefaultResultOutput()).Execute);
                case opType.sub:
                    return new Calculation(a, b, new SumOperation(new DefaultResultOutput()).Execute);
                case opType.div:
                    return new Calculation(a, b, new SumOperation(new DefaultResultOutput()).Execute);
                case opType.mul:
                    return new Calculation(a, b, new SumOperation(new DefaultResultOutput()).Execute);
                default: throw new ParseException();
            }
        }

        static readonly Parser<Calculation> constant = Parse.Decimal.Select(x => new Calculation(double.Parse(x))).Named("number");

        static readonly Parser<opType> add = Operator("+", opType.add);
        static readonly Parser<opType> sub = Operator("-", opType.sub);
        static readonly Parser<opType> div = Operator("/", opType.div);
        static readonly Parser<opType> mul = Operator("*", opType.mul);
        

        static Parser<object> Test(Parser<double> value)
        {
            Parser<object> val = Parse.Return<object>(value);

            return val;
        }

        static Parser<Calculation> Test2(Parser<object> value)
        {
            //TestClass ttt = value;

            Parser<Calculation> val = (Parser<Calculation>)value;

            return val;
        }

        static Calculation Test3(object o)
        {
            var qwe = o as Parser<object>;

  
            var ttttt = from v in qwe
                        select v;

            return new Calculation(5d, 5d, new SumOperation(new DefaultResultOutput()).Execute);
        }

        static readonly Parser<Calculation> factor = (from lparen in Parse.Char('(')
                                                 from ex in Parse.Ref(() => expr)
                                                 from rparen in Parse.Char(')')
                                                 select ex).XOr(constant);

        //static readonly Parser<object> operand = ((from sign in Parse.Char('-')
        //                                           from fact in factor
        //                                           select -fact).XOr(factor)).Token();

        static readonly Parser<Calculation> term1 = Parse.ChainOperator(mul.Or(div), factor, binaryApply);
        static readonly Parser<Calculation> expr = Parse.ChainOperator(add.Or(sub), term1, binaryApply);
    }
}
