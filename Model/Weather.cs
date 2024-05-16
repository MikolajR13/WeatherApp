namespace Instrukcja.Model
{
    public class Weather //Dosłownie 1:1 odpowiedź z API + WAŻNE => Id1 - klucz główny, Id - normalna zmienna (odpowiedź z API daje takie same Id czasami) <= WAŻNE 
    {   
        public int Id1 { get; set; }
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
