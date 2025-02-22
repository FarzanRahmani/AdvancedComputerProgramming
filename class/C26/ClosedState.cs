using System;

class ClosedState : AccountState
{
    public ClosedState(Action onUnFrozen) : base(onUnFrozen)
    {
    }
}