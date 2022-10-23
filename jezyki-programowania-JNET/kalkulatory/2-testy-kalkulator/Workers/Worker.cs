
using System;
using System.Collections.Generic;
using System.Text;

namespace kalkulatory
{
    public class Worker
    {
        private ICalculator calculator;
        public Worker(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public string Work(string a, string b)
        {
            return calculator.Eval(a, b);
        }
    }
}
