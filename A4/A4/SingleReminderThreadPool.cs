using System;
using System.Threading;

namespace A4
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public SingleReminderThreadPool( string msg , int delay)
        {
            Delay = delay;
            Msg = msg;
        }
        public int Delay {get;private set;}

        public string Msg {get;private set;}

        public event Action<string> Reminder;

        public void Start()
        {
            // System.Threading.Tasks.Task.Delay(Delay).Wait();
            Thread.Sleep(Delay);
            ThreadPool.QueueUserWorkItem( (obj) => Reminder(Msg));
        }
    }
}