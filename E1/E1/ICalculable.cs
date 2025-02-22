using System;

namespace E1
{
    public interface ICalculable<_Type>
    {
        _Type MultiplyBy(_Type other);
        _Type AddWith(_Type other);
        void LoadFromStr(string str);
        void Reset();
        void RndSet();
        void Set(_Type o);
        _Type Clone();
        
        _Type PlusIdentity { get; }
        _Type NegIdentity { get; }
    } 
}
