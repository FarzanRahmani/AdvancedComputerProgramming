using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8.StatePattern
{
    public interface IState // interface 
    {
        IState EnterZeroDigit();
        IState EnterNonZeroDigit(char c);
        IState EnterOperator(char c);
        IState EnterPoint();
        IState EnterEqual();
    }
}
