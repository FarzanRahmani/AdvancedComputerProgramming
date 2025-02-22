namespace A8.StatePattern
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        public PointState(Calculator calc) : base(calc) { } // ctor

        //#1 لطفا!
        public override IState EnterPoint() => this; // daghighan ein state accumalation vali tanha farghesh ine ke . kar nemikone
    }
}