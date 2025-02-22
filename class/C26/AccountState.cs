using System;

abstract class AccountState : IAccountState
{
    protected Action OnUnFrozen; // private dastresi nadare

    protected AccountState(Action onUnFrozen)
    {
        OnUnFrozen = onUnFrozen;
    }
    public virtual IAccountState Close() => new ClosedState(OnUnFrozen);
    public virtual IAccountState Deposit(Action addToBalance) => this;
    public virtual IAccountState Freeze() => this;
    public virtual IAccountState HolderVerified() => this;
    public virtual IAccountState Withdraw(Action subFromBalance) => this;
}