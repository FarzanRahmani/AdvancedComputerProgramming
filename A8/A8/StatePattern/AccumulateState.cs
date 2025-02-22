using static System.Console;

namespace A8.StatePattern
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { } // ctor base

        // #7 لطفا
        public override IState EnterEqual() => ProcessOperator(new ComputeState(this.Calc)); // = -> compute state
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0'); // chon dar in halat ba zadan  taghir ijad mishe
        public override IState EnterNonZeroDigit(char c) // adad ha namayesh dade mishan
        {
            // #8 لطفا!
            this.Calc.Display += c;
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c) => ProcessOperator(new ComputeState(this.Calc), c); // har operator ke seda zade shod bayad be to compute state chon masala age 2+3+4 bezanim mishe 5+4
        public override IState EnterPoint() // vared halat momayezi mishe ke shabihe accumalate ast
        {
            // #10 لطفا!
            this.Calc.Display += '.';
            return new PointState(this.Calc);
        }
    }
}