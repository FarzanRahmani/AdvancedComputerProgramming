using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {}

        public static int GetObjectType(object o)
        {
            if (o is string)
                return 0;
            else if (o is int[])
                return 1;
            else if (o is int)
                return 2;
            else
                return 5;
        }

        public static bool IdealHusband(FutureHusbandType fht)
        {
            if( ((int)fht > 8 && (int)fht < 14) || ((int)fht == 6) )
                return true;
            return false;
        }
    }
}
