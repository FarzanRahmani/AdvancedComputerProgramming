namespace A8.StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { } // ctor base

        public override IState EnterEqual() // tebgh soal error mide
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        public override IState EnterNonZeroDigit(char c) // adad ha namayesh dade mishan va ghabeliat accumalate daran
        {
            // #3 لطفا!
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterZeroDigit() // mire start state
        {
            // #4 لطفا
            this.Calc.Display = "0";
            return new StartState(this.Calc);
        }

        // #5 لطفا
        public override IState EnterOperator(char c) => ProcessOperator(new StartState(this.Calc),c);  // har operator ke seda zade shod bayad be to compute state chon masala age 2+3+4 bezanim mishe 5+4

        public override IState EnterPoint() // vared halat momayezi mishe ke shabihe accumalate ast
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}