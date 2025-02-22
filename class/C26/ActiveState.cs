using System;

class ActiveState : AccountState
{
    public ActiveState(Action onUnfrozen)
    : base(onUnfrozen)
    {
    }

    public override IAccountState Deposit(Action addToBalance)
    {
        addToBalance();
        return this;
    }

    public override IAccountState Freeze() => new FrozenState(this.OnUnFrozen);

    public override IAccountState Withdraw(Action subFromBalance)
    {
        subFromBalance();
        return this;
    }
}