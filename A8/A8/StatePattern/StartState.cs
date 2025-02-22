using System;

namespace A8.StatePattern
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { } // ctor

        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc)); // voroodi dovom null(=)

        public override IState EnterZeroDigit() // taghiri nemikone va dar in state mimoone
        {
            this.Calc.Display = "0";
            return this;
        }

        public override IState EnterNonZeroDigit(char c) // adad ha namayesh dade mishan va ghabeliat accumalation daran
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterOperator(char c) =>  // har operator ke seda zade shod bayad be to compute state chon masala age 2+3+4 bezanim mishe 5+4
            ProcessOperator(new ComputeState(this.Calc), c);

        public override IState EnterPoint() // vared halat momayezi mishe ke shabihe accumalate ast
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}