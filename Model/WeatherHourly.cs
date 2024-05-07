namespace Instrukcja.Model
{
    public class WeatherHourly
    {
        public long Dt { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Dew_point { get; set; }
        public double Uvi { get; set; }
        public int Clouds { get; set; }
        public int Visibility { get; set; }
        public double Wind_speed { get; set; }
        public double Wind_gust { get; set; }
        public int Wind_deg { get; set; }
        public List<Weather> Weather { get; set; }
        public double Pop { get; set; }
    }
}
