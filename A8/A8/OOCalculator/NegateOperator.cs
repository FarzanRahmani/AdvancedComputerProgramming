using System;
using System.IO;

namespace A8.OOCalculator
{
    public class NegateOperator : UnaryOperator
    {
        public NegateOperator(TextReader reader)
        : base(reader)
        {
        }

        public override string OperatorSymbol => "-";

        public override double Evaluate() => -Operand.Evaluate(); 
    }
}