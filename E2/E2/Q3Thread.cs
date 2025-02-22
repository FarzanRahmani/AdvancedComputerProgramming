using System;
using System.Threading;

namespace E2
{
    public class Q3Thread
    {
        private Random RndGen = new Random(1);
        private static int _InstanceCount = 0;
        public static int InstanceCount => _InstanceCount;

        

        private static Q3Thread _Instance = null;

        public static void ResetInstanceToNull() 
        {
            _Instance = null;
            _InstanceCount = 0;
        }
        public static Q3Thread Instance()
        {
            string locking_object = "Lock";
            lock(locking_object)
            {
                if (_Instance == null)
                {
                    _Instance = new Q3Thread();
                }
            }
            return _Instance;
        }

        public int GetSomeRandomNumber() => RndGen.Next();

        private Q3Thread()
        {
            Interlocked.Increment(ref _InstanceCount);
        }
    }
}