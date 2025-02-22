using System;
using System.IO;

namespace A8.OOCalculator
{
    public class NumberExpression : Expression
    {
        protected double Number;

        public NumberExpression(string line)
        {
            if(line != null)
                Number = double.Parse(line);
            else
                Number = 0;
        }

        public override double Evaluate() => Number;

        public override string ToString() => Number.ToString();
    }
}