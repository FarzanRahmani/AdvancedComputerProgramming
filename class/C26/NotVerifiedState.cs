using System;

class NotVerifiedState : AccountState
{
    public NotVerifiedState(Action onUnfrozen)
    : base (onUnfrozen)
    {
    }

    public override IAccountState Deposit(Action addToBalance)
    {
        addToBalance();
        return this;
    }

    // public IAccountState Freeze() => this; // chon verify nist bad unreeze she active mishe va bug pish miad

    public override IAccountState HolderVerified() => new ActiveState(this.OnUnFrozen);

}