using System;

namespace E1
{
    public struct DoubleWithOp :
        ICalculable<DoubleWithOp>, IEquatable<DoubleWithOp>
    {
        public DoubleWithOp(double value)
        {
            Value = value;
        }

        public double Value {get; private set;}
        private static Random Rnd = new Random(0);
        public DoubleWithOp PlusIdentity => new DoubleWithOp(1);

        public DoubleWithOp NegIdentity => new DoubleWithOp(-1);

        public DoubleWithOp AddWith(DoubleWithOp other)
        {
            return new DoubleWithOp(this.Value+other.Value);
        }

        public DoubleWithOp Clone()
        {
            return new DoubleWithOp(this.Value);
        }

        public void LoadFromStr(string str)
        {
            Value = double.Parse(str);
        }

        public DoubleWithOp MultiplyBy(DoubleWithOp other)
        {
            return new DoubleWithOp(this.Value*other.Value);
        }

        public void Reset()
        {
            this.Value = 0;
        }

        public void RndSet()
        {
            this.Value = Rnd.Next();
        }

        public void Set(DoubleWithOp o)
        {
            this.Value = o.Value;
        }

        public bool Equals(DoubleWithOp other)
        {
            return other.Value == this.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
