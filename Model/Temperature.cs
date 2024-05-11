namespace Instrukcja.Model
{
    public class Temperature
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
