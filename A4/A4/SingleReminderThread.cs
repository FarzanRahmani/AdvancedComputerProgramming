using System;
using System.Threading;

namespace A4
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReiminderThread = null;

        public SingleReminderThread( string msg , int delay)
        {
            Delay = delay;
            Msg = msg;
        }

        public int Delay {get; private set;}

        public string Msg {get; private set;}

        public event Action<string> Reminder;

        public void Start()
        {
            Thread.Sleep(Delay);
            ReiminderThread = new Thread( () => Reminder(Msg));
            ReiminderThread.Start();
        }
        #region TODO

        #endregion
    }
}