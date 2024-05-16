namespace Instrukcja.Model
{
    public class WeatherHourly //wszystko z API oprócz podpisanych 
    {
        public int Id { get; set; } //
        public long Dt { get; set; } //
        public int WeatherDailyId { get; set; } //klucz obcy do relacji z WeatherDaily - ustawiany ręcznie w ReadDataBaseService.cs (katalog Services)
        public DateTime DateHourly { get; set; } //Data ustawiana ręcznie w Weather.razor (24-12-2024 00:00:00)
        public TimeOnly Time { get; set; } //czas ustawiany ręcznie w Weather.razor (12:32:11)
        public double Temp { get; set; } //
        public double Feels_like { get; set; } //
        public int Pressure { get; set; } //
        public int Humidity { get; set; } //
        public double Dew_point { get; set; } //
        public double Uvi { get; set; } //
        public int Clouds { get; set; } //
        public int Visibility { get; set; }
        public double Wind_speed { get; set; } //
        public string LocationName { get; set; }
        public double Wind_gust { get; set; } //
        public int Wind_deg { get; set; } //
        public List<Weather> Weather { get; set; } //zmienna nawigacyjna do Weather.cs //
        public double Pop { get; set; } //
        public WeatherDaily WeatherDaily { get; set; }   //zmienna nawigacyjna do WeatherDaily.cs
    }
}
