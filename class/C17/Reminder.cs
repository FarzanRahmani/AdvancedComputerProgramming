using System.Timers;

public class Reminder
{
    public delegate void ReminderDelegate(string msg); // function poiter

    public ReminderDelegate ReminderCall;

    public string Msg {get; private set;}

    private Timer Timer;

    public Reminder(string msg, int seconds)
    {
        this.Msg = msg;
        this.Timer = new Timer(seconds * 1000);
        this.Timer.Elapsed += (sender, args) => this.ReminderCall(msg);
    }
}