using System;
using System.Collections.Generic;
using System.Text;

namespace kalkulatory
{
    public class PlusCalc : ICalculator
    {
        public string Eval(string a, string b)
        {
            return (int.Parse(a) + int.Parse(b)).ToString();
        }
    }
}
