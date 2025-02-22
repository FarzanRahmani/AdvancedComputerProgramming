using System;
using System.IO;

namespace A8.OOCalculator
{
    public class SquareOperator : UnaryOperator
    {
        public SquareOperator(TextReader reader)
        : base(reader)
        {
        }

        public override string OperatorSymbol => "Square";

        public override double Evaluate() => Operand.Evaluate()*Operand.Evaluate();

    }
}