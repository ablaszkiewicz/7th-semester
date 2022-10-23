using System;
using System.Collections.Generic;
using System.Text;

namespace kalkulatory
{
    public class CatCalc : ICalculator
    {
        public string Eval(string a, string b)
        {
            return a + b;
        }
    }
}
