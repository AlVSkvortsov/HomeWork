using Calculator;
using Calculator.Core.ResultOutput;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPICalculator.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public ContentResult Get()
        {
            List<string> methods = new List<string>
            {
                "<a href=\"https://localhost:44365/calculator/Sum?first=5&second=7\">Сумма: 5+7</a>",
                "<a href=\"https://localhost:44365/calculator/Multiplication?first=5&second=7\">Произведение: 5*7</a>",
                "<a href=\"https://localhost:44365/calculator/Division?first=4&second=2\">Деление: 4/2</a>",
                "<a href=\"https://localhost:44365/calculator/Subtraction?first=7&second=5\">Разница: 7-5</a>"
            };
            string reference = string.Join("<br><br>", methods);

            string html = $"<html><head><meta charset = \"utf-8\"/></head><body>{reference}</body></html>";

            return base.Content(html, "text/html");
        }

        ///https://localhost:44365/calculator/Sum?first=5&second=7
        [HttpGet]
        public IResultOutput Sum(double first, double second)
        {
            IResultOutput result = Calculators.SimpleCalculator(first, second, '+');
            return result;
        }

        ///https://localhost:44365/calculator/Multiplication?first=5&second=7
        [HttpGet]
        public IResultOutput Multiplication(double first, double second)
        {
            IResultOutput result = Calculators.SimpleCalculator(first, second, '*');
            return result;
        }

        ///https://localhost:44365/calculator/Division?first=4&second=2
        [HttpGet]
        public IResultOutput Division(double first, double second)
        {
            IResultOutput result = Calculators.SimpleCalculator(first, second, '/');
            return result;
        }

        ///https://localhost:44365/calculator/Subtraction?first=7&second=5
        [HttpGet]
        public IResultOutput Subtraction(double first, double second)
        {
            IResultOutput result = Calculators.SimpleCalculator(first, second, '-');
            return result;
        }

    }
}
