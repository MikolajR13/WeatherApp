namespace Instrukcja.Model
{
    public class WeatherDaily
    {
        public int Id { get; set; }
        public int TempId { get; set; }
        public int FeelsLikeId { get; set; }
        public long Dt { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public long Moonrise { get; set; }
        public long Moonset { get; set; }
        public double Moon_phase { get; set; }
        public Temperature Temp { get; set; }
        public Temperature Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Dew_point { get; set; }
        public double Wind_speed { get; set; }
        public double Wind_gust { get; set; }
        public int Wind_deg { get; set; }
        public int Clouds { get; set; }
        public double Uvi { get; set; }
        public double Pop { get; set; }
        public List<Weather> Weather { get; set; }
    }
}
