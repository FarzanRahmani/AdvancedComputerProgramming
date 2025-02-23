﻿namespace A8.StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// #2 لطفا!
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { } // ctor base
        public override IState EnterEqual() => this;
        public override IState EnterNonZeroDigit(char c) => this;
        public override IState EnterZeroDigit() => this;
        public override IState EnterOperator(char c) => this;
        public override IState EnterPoint() => this;
        // har kari konim dar in halat mimoone magar inke kharej shim
    }
}