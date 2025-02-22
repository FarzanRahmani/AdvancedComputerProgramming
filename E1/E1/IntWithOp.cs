using System;

namespace E1
{
    public struct IntWithOp : ICalculable<IntWithOp>, IEquatable<IntWithOp>
    {
        private static Random Rnd = new Random(0);

        public IntWithOp(int value)
        {
            Value = value;
        }

        public int Value {get; private set;}

        public IntWithOp PlusIdentity => new IntWithOp(1);

        public IntWithOp NegIdentity => new IntWithOp(-1);

        public IntWithOp AddWith(IntWithOp other)
        {
            return new IntWithOp(this.Value+other.Value);
        }

        public IntWithOp Clone()
        {
            return new IntWithOp(this.Value);
        }

        public bool Equals(IntWithOp other)
        {
            return this.Value == other.Value;
        }

        public void LoadFromStr(string str)
        {
            Value = int.Parse(str);
        }

        public IntWithOp MultiplyBy(IntWithOp other)
        {
            return new IntWithOp(this.Value * other.Value);
        }

        public void Reset()
        {
            this.Value = 0;
        }

        public void RndSet()
        {
            Value = Rnd.Next();
        }

        public void Set(IntWithOp o)
        {
            this.Value = o.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
