using System;
using System.IO;

namespace A8.OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        protected Expression LHS;
        protected Expression RHS;

        public BinaryOperator()
        {
            // throw new NotImplementedException();
        }

        public BinaryOperator(TextReader reader)
        {
            // reader.ReadLine();
            LHS = Expression.GetNextExpression(reader);
            RHS = Expression.GetNextExpression(reader);
            // LHS = Expression.GetNextExpression(reader);
            
        }

        public abstract string OperatorSymbol { get; }

        public sealed override string ToString() => "("+LHS.ToString()+OperatorSymbol+RHS.ToString()+")";

    }
}