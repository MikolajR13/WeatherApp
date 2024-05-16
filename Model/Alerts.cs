namespace Instrukcja.Model
{
    //Ogólnie wszystkie klasy w Model mapują dane, które są w odpowiedzi z API +  dodatkowe zmienne pomocnicze lub zmienne nawigacyjne dla bazy danych
    public class Alerts //w odpowiedzi API są alerty ale jeszcze tego nie przetwarzamy
    {
        public string Sender_name { get; set; }
        public string Event { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
    }
}
