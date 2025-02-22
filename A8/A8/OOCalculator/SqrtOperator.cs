using System;
using System.IO;

namespace A8.OOCalculator
{
    public class SqrtOperator : UnaryOperator
    {
        public SqrtOperator(TextReader reader)
        : base(reader)
        {
        }

        public override string OperatorSymbol => "Sqrt";

        public override double Evaluate() => System.Math.Sqrt(Operand.Evaluate());
    }
}