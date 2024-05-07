namespace Instrukcja.Model
{
    public class WeatherResponse
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Timezone { get; set; }
        public int Timezone_offset { get; set; }
        public CurrentWeather Current { get; set; }
        public List<WeatherMinutely> Minutely { get; set; }
        public List<WeatherHourly> Hourly { get; set; }
        public List<WeatherDaily> Daily { get; set; }
        public List<Alerts> Alerts { get; set; }
    }
}
