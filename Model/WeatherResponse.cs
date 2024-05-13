namespace Instrukcja.Model
{
    public class WeatherResponse //klasa która przyjmuje odpowiedź api - tzn tworzymy obiekt o typie tej klasy, w którym zapisujemy wszystkie dane
    {
        public double Lat { get; set; } //szerokość geograficzna
        public double Lon { get; set; } //długość geograficzna
        public string Timezone { get; set; } //strefa czasowa
        public int Timezone_offset { get; set; } // nie pamiętam ale jest w pliku Guide for newcomers link do dokumentacji API
        //tworzenie obiektów i list o typach pogód 
        public CurrentWeather Current { get; set; } 
        public List<WeatherMinutely> Minutely { get; set; }
        public List<WeatherHourly> Hourly { get; set; }
        public List<WeatherDaily> Daily { get; set; }
        public List<Alerts> Alerts { get; set; }
    }
}
