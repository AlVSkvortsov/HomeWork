using Calculator;
using Calculator.Processing.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            //var test = new SimpleCalculator<>

            //var test = Calculators.SimpleCalculator(5, 5, '+');

            var test1 = Calculators.MainCalculator("2*(5+7)");

            //Calculation operations = new Calculation(5,5, new SummFunctions().Execute);
            //Calculation operations1 = new Calculation(operations, 5, new SummFunctions().Execute);
            //Calculation operations2 = new Calculation(operations, operations1, new SummFunctions().Execute);

            //Calculation operations = new Calculation(5,5d, new SummFunctions().Execute);
            //Calculation operations1 = new Calculation(operations, 5d, new SummFunctions().Execute);
            //Calculation operations2 = new Calculation(operations, operations1, new SummFunctions().Execute);



            //double test = operations2.Execute();


            Console.ReadKey();
        }

        
    }
    //public abstract class Operation
    //{
    //    //private readonly IReadOnlyList<IValidator> _validators;
    //    public virtual string DisplayName => this.GetType().Name;
    //    public List<string> ValidationResults { get; }
    //    public Operation() { }
    //    //public Operation(IReadOnlyList<IValidator> validators) => _validators = validators;

    //    public virtual double Execute(double FirstArgument, double SecondArgument)
    //    {
    //        Validate();

    //        return 0;
    //    }

    //    public abstract double Execute(Calculation firstValue, double secondValue);

    //    public abstract double Execute(double firstValue, Calculation secondValue);

    //    public abstract double Execute(Calculation firstValue, Calculation secondValue);

    //    private bool Validate()
    //    {
    //        //if (_validators == null)
    //        //    return true;

    //        //bool result = true;
    //        //List<string> ValidationResults = new List<string>();

    //        //foreach (IValidator validator in _validators)
    //        //{
    //        //    if (validator.IsValid(this))
    //        //    {
    //        //        continue;
    //        //    }
    //        //    ValidationResults.Add($"{validator.Id} is not valid");
    //        //    result = false;
    //        //}

    //        //return result;
    //        return true;
    //    }
    //}

    //public class SummFunctions
    //{
    //    public double Execute(object firstValue, object secondValue)
    //    {
    //        var firstCalc = firstValue as Calculation;
    //        var secondCalc = secondValue as Calculation;

    //        double first = (firstCalc == null) ? (double)firstValue : firstCalc.Execute();
    //        double second = (secondCalc == null) ? (double)secondValue : secondCalc.Execute();


    //        return first + second;
    //    }


    //}

    //public class Calculation
    //{
    //    public  object _firstCalc;
    //    public object _secondCalc;
    //    private Func<object, object, double> _functions { get; set; }

    //    public Calculation(object firstValue, object secondValue, Func<object, object, double> functions)
    //    {
    //        if ((firstValue is Calculation || firstValue is double)
    //            && (secondValue is Calculation || secondValue is double))
    //        {
    //            _firstCalc = firstValue;
    //            _secondCalc = secondValue;
    //            _functions = functions;
    //        }
    //        else
    //        {
    //            throw new ArgumentException();
    //        }
    //    }

    //    public double Execute()
    //    {
    //        return _functions(_firstCalc, _secondCalc);
    //    }
    //}

    //public class SummFunctions : Operation
    //{
    //    public override double Execute(double firstValue, double secondValue)
    //    {
    //        return firstValue + secondValue;
    //    }
    //    public override double Execute(Calculation firstValue, double secondValue)
    //    {
    //        return firstValue.Execute() + secondValue;
    //    }
    //    public override double Execute(double firstValue, Calculation secondValue)
    //    {
    //        return firstValue + secondValue.Execute();
    //    }
    //    public override double Execute(Calculation firstValue, Calculation secondValue)
    //    {
    //        return firstValue.Execute() + secondValue.Execute();
    //    }
    //}

    //public class Calculation
    //{
    //    private Calculation _firstFunc;
    //    private double _first;
    //    private Calculation _secondFunc;
    //    private double _second;
    //    private Func<double, double, double> _numbersFunct { get; set; }
    //    private Func<Calculation, double, double> _functLeft { get; set; }
    //    private Func<double, Calculation, double> _functRight { get; set; }
    //    private Func<Calculation, Calculation, double> _functions { get; set; }

    //    public Calculation(double first, double second, Func<double, double, double> functions) 
    //    {
    //        _first = first;
    //        _second = second;
    //        _numbersFunct = functions;
    //    }

    //    public Calculation(Calculation first, double second, Func<Calculation, double, double> functions)
    //    {
    //        _firstFunc = first;
    //        _second = second;
    //        _functLeft = functions;
    //    }

    //    public Calculation(double first, Calculation second, Func<double, Calculation, double> functions)
    //    {
    //        _first = first;
    //        _secondFunc = second;
    //        _functRight = functions;
    //    }

    //    public Calculation(Calculation firstValue, Calculation secondValue, Func<Calculation, Calculation, double> functions)
    //    {
    //        _secondFunc = firstValue;
    //        _secondFunc = secondValue;
    //        _functions = functions;
    //    }

    //    public double Execute()
    //    {
    //        if (_secondFunc == null && _secondFunc == null)
    //            return _numbersFunct(_first, _second);

    //        if (_secondFunc != null && _secondFunc == null)
    //            return _functLeft(_secondFunc, _second);

    //        if (_secondFunc == null && _secondFunc != null)
    //            return _functRight(_first, _secondFunc);

    //        if (_secondFunc != null && _secondFunc != null)
    //            return _functions(_secondFunc, _secondFunc);

    //        throw new Exception("Ошибка, при выполнении по действиям!");
    //    }
    //}
}
