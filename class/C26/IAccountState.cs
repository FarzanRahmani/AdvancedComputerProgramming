using System;

interface IAccountState
{
    IAccountState Deposit(Action addToBalance);
    IAccountState Withdraw(Action subFromBalance);
    IAccountState HolderVerified();
    IAccountState Freeze();
    IAccountState Close();
}