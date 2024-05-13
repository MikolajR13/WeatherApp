namespace Instrukcja.Model
{
    public class WeatherDaily //większość z API a jeżeli nie to jest opisane do czego co służy
    {
        public int Id { get; set; }
        public int TempId { get; set; } //klucz obcy do Temperature ( w temperature to jest TemperatureId )
        public DateTime DateDaily { get; set; } //Data - to co w Weather.razor dodajemy ręcznie ( 23-12-2024 00:00:00)
        public int FeelsLikeId { get; set; } // klucz obcy do Temperature ( w temperature to jest TemperatureFellsId )
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
        public List<Weather> Weather { get; set; } //zmienna nawigacyjna 

        public List<WeatherHourly> WeatherHourlies { get; set; } //zmienna nawigacyjna na potrzeby bazy danych 
    }
}
