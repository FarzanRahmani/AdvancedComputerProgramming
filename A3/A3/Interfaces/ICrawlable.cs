namespace A3.Interfaces
{
    public interface ICrawlable
    {
        double SpeedRate {get; set;}
        string Crawl();
    }
}