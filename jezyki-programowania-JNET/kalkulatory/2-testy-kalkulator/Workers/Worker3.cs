
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace kalkulatory
{
    public class Worker3
    {
        [Dependency]
        public ICalculator Calculator { get; set; }

        public string Work(string a, string b)
        {
            return Calculator.Eval(a, b);
        }
    }
}
