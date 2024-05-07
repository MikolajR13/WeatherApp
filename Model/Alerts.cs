namespace Instrukcja.Model
{
    public class Alerts
    {
        public string Sender_name { get; set; }
        public string Event { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
    }
}
