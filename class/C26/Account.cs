using System;
using System.Timers;

class Account
{
    public double Balance {get; private set;}
    IAccountState AccountState; // NotVerifiedState or ActiveSate or ClosedSate or FrozenState 
    public Account(Action onUnfreeze, int freezeAfter)
    {
        this.AccountState = new NotVerifiedState(onUnfreeze);

        Timer t = new Timer(freezeAfter);
        t.Elapsed += (a,s) => Freeze();
        t.Start();
    }
    
    public void Deposit(double amount) =>
        this.AccountState = this.AccountState.Deposit( () => this.Balance += amount);

    public void Withdraw(double amount) =>
        this.AccountState = this.AccountState.Withdraw(() => this.Balance -= amount);

    public void Close() => 
        this.AccountState = this.AccountState.Close();

    public void HolderVerified() =>
        this.AccountState = this.AccountState.HolderVerified();

    public void Freeze() =>
        this.AccountState = this.AccountState.Freeze();
}