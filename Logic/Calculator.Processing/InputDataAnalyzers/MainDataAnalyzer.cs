using Calculator.Core;
using Calculator.Core.InputDataAnalyzers;
using Calculator.Core.ResultOutput;
using Calculator.Processing.Operations;
using Calculator.Processing.ResultOutput;
using Sprache;
using System;

namespace Calculator.Processing.InputDataAnalyzers
{
    public class MainDataAnalyzer<TResultOutput> : InputDataAnalyzer<TResultOutput>
         where TResultOutput : class, IResultOutput
    {
        public MainDataAnalyzer(TResultOutput resultOutput) : base(resultOutput) { }
        public override ICalculation Analysis(string expression)
        {
            try
            {
                TResultOutput resultOutput = ResultOutput;

                return expr.Parse(expression); 
            }
            catch (Exception ex)
            {
                ResultOutput.Error(new Exception($"Error in {this.GetType().Name}: {ex.Message}", ex));
                return null;
            }
        }

        enum opType
        {
            sum, sub, mul, div
        }

        static Parser<opType> Operator(string op, opType type)
        {
            return Parse.String(op).Token().Return(type);
        }

        static Calculation binaryApply(opType op, Calculation a, Calculation b)
        {
            //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            IResultOutput resultOutput = new DefaultResultOutput();
            //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
            switch (op)
            {
                case opType.sum:
                    return new Calculation(a, b, new SumOperation(resultOutput).Execute);
                case opType.sub:
                    return new Calculation(a, b, new SubtractionOperation(resultOutput).Execute);
                case opType.div:
                    return new Calculation(a, b, new DivisionOperation(resultOutput).Execute);
                case opType.mul:
                    return new Calculation(a, b, new MultiplicationOperation(resultOutput).Execute);
                default: throw new ParseException();
            }
        }

        static readonly Parser<Calculation> constant = Parse.Decimal.Select(x => new Calculation(double.Parse(x))).Named("number");

        static readonly Parser<opType> sum = Operator("+", opType.sum);
        static readonly Parser<opType> sub = Operator("-", opType.sub);
        static readonly Parser<opType> div = Operator("/", opType.div);
        static readonly Parser<opType> mul = Operator("*", opType.mul);

        static readonly Parser<Calculation> factor = (from lparen in Parse.Char('(')
                                                 from ex in Parse.Ref(() => expr)
                                                 from rparen in Parse.Char(')')
                                                 select ex).XOr(constant);

        static readonly Parser<Calculation> operand = ((from sign in Parse.Char('-')
                                                   from fact in factor
                                                   select fact.IsNegative(true)).XOr(factor)).Token();

        static readonly Parser<Calculation> term = Parse.ChainOperator(mul.Or(div), operand, binaryApply);
        static readonly Parser<Calculation> expr = Parse.ChainOperator(sum.Or(sub), term, binaryApply);
    }
}
