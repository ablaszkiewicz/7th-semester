using System;
using System.Collections.Generic;
using System.Text;

namespace kalkulatory
{
    public class StateCalc : ICalculator
    {
        private int counter;
        public StateCalc(int initialCounterState)
        {
            counter = initialCounterState;
        }
        public string Eval(string a, string b)
        {
            return $"{a + b}. Counter: {counter++}";

        }
    }
}
