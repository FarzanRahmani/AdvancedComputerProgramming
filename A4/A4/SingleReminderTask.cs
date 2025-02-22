using System;
using System.Threading;
using System.Threading.Tasks;

namespace A4
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReiminderTask = null;

        public SingleReminderTask( string msg , int delay)
        {
            Delay = delay;
            Msg = msg;
        }

        public int Delay {get;private set;}

        public string Msg {get;private set;}

        public event Action<string> Reminder;

        public void Start()
        {
            Task.Delay(Delay).Wait();
            ReiminderTask = new Task(() => Reminder(Msg));
            ReiminderTask.Start();
        }
    }
}