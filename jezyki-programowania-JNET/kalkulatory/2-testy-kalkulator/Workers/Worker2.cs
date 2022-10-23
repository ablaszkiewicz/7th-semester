
using System;
using System.Collections.Generic;
using System.Text;

namespace kalkulatory
{
    public class Worker2
    {
        private ICalculator calculator;

        public void Initialize(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public string Work(string a, string b)
        {
            return calculator.Eval(a, b);
        }
    }
}
