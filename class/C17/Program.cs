using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace C17
{
    interface IReminder
    {
        event Reminder.ReminderDelegate Happened;        
        // Reminder.ReminderType ReminderType {get; set;}
    }
    class Reminder: IReminder
    {
        public string Msg{ get; private set;}
        public int Duration{ get; private set;}

        public Reminder(string msg)
        {
            this.Msg = msg;
        }

        public Reminder(string msg, int durationSeconds)
        {
            this.Msg = msg;
            this.Duration = durationSeconds;
            this.Start(this.Duration);
        }

        public void Start(int durationSeconds)
        {
            Task.Delay(durationSeconds * 1000).ContinueWith((t) => {
                this.Happened(this.Msg);
            });
        }

        public void StartInterval(int durationSeconds)
        {
            Task.Run( () => {
                while(true)
                {
                    Task.Delay(durationSeconds* 1000).Wait();
                    this.Happened(this.Msg);
                }
            } );
        }


        public delegate void ReminderDelegate(string msg);

        public event ReminderDelegate Happened;
        // event hamoon delegate ee faghat shabih get va set add+= va remove-= dare va too interface mitoone estefade she
    }

    class Program
    {        
        static void TelegramCall(string msg)
        {
            //Telegram.SendMsg("@1234123", msg)
            Console.WriteLine(msg);
        }
        static void Main1(string[] args)
        {
            int n = 5; // n --> event or delegate (mesl moteghayer)      5 --> function
            Reminder.ReminderDelegate myNewDel = TelegramCall;
            myNewDel += TelegramCall;
            

            Reminder r = new Reminder("Call my mom", 2);
            r.Happened += TelegramCall;
            r.Happened += (msg) => {
                System.Console.WriteLine("Call 0912349234 + " + msg);
            };

            r.Happened += (msg) => {
                System.Console.WriteLine("Msg Telegram 0912349234 + " + msg);
            };

            r.Happened += (msg) => {
                System.Console.WriteLine("Msg WhatsApp 0912349234 + " + msg);
            }; // or -=

            for(int i=0; i<100; i++)
            {
                Thread.Sleep(100);
                System.Console.WriteLine("Waiting");
            }
        }


        static void TestFn(object sender, System.Timers.ElapsedEventArgs args)
        {
            System.Console.WriteLine("TestFn");
        }

        static void Main(string[] args)
        {            
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.AutoReset = true; // tekrar mishe mesl interval
            timer.Elapsed += (sender, args) => { // is a event that Occurs when the interval elapses
                System.Console.WriteLine("Happened"); // sender --> timer
                // System.Timers.Timer t = sender as System.Timers.Timer;
            };

            timer.Elapsed += (sender, args) => {
                System.Console.WriteLine("Happy");
            };

            timer.Elapsed += (sender, args) => {
                System.Console.WriteLine("Great!");
            };
            timer.Elapsed += TestFn;
            timer.Start();

            for(int i=0; i<100; i++)
            {
                Thread.Sleep(100); // current thread
                System.Console.WriteLine("Waiting");

                if (i > 20)
                    timer.Elapsed -= TestFn;
                
            }
        }

        static void Main10(string[] args)
        {            
            int number = 0;
            string number_lock = "number_lock"; // number_lock bayad ref type bashe
            Stopwatch sw = Stopwatch.StartNew();

            Task t1 = new Task( () => {
                for(int i=0; i<100_000; i++)
                {
                    lock (number_lock) // bishtar tool mikeshe
                        number++;
                    // in CPU    rx-->register        number -->RAM
                    int rx = number;
                    rx++;
                    number = rx;
                    // CPu
                    
                    Interlocked.Increment(ref number); // kamtar tool mikeshe     hazine in nsebat be lock kamtare
                }
            });

            Task t2 = new Task( () => {
                for(int i=0; i<100_000; i++)    
                {
                    lock (number_lock)
                        number--;
                    number--;
                    // in CPU    rx-->register
                    int rx = number;
                    rx--;
                    number = rx;
                    // CPu
                    
                    Interlocked.Decrement(ref number);
                }
            });

            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            sw.Stop();
            System.Console.WriteLine(sw.ElapsedMilliseconds);
            System.Console.WriteLine(number);

        }
    }
}
