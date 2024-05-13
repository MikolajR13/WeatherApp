namespace Instrukcja.Model
{
    public class Temperature //Dosłownie 1:1 odpowiedź z API + TemperatureId oraz TemperatureFellId - potrzebne do stworzenia relacji w bazie danych
    {
        public int TemperatureId { get; set; }
        public int TemperatureFellsId { get; set; }
        public double Day { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Night { get; set; }
        public double Eve { get; set; }
        public double Morn { get; set; }
    }
}
