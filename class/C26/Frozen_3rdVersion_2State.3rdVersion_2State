// using System;
// class FrozenState : IFreezable
// {
//     private Action OnUnFreeze;
//     public FrozenState(Action onUnfreeze)
//     {
//         this.OnUnFreeze = onUnfreeze;
//     }
//     public IFreezable Deposit()
//     {
//         OnUnFreeze();
//         return new ActiveState(this.OnUnFreeze);
//     }

//     public IFreezable Freeze() => this;

//     public IFreezable Withdraw()
//     {
//         OnUnFreeze();
//         return new ActiveState(this.OnUnFreeze);
//     }
// }