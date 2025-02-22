using System;

class FrozenState : AccountState
{

    public FrozenState(Action onUnFrozen) : base(onUnFrozen)
    {
    }

    public override IAccountState Deposit(Action addToBalance)
    {
        addToBalance();
        this.OnUnFrozen(); // SMS
        return new ActiveState(this.OnUnFrozen);
    }

    public override IAccountState Withdraw(Action subFromBalance)
    {
        subFromBalance();
        this.OnUnFrozen();
        return new ActiveState(this.OnUnFrozen);    
    }
}