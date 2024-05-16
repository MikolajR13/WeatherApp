namespace Instrukcja.Model
{
    public class WeatherDataResult //klasa służąca do odczytu danych dziennych i godzinowych z bazy danych - 2 listy jedna dla danych dziennych DailiesData, druga dla godzinowych HourliesData
    {
        public List<WeatherDaily> DailiesData { get; set; }
        public List<WeatherHourly> HourliesData { get; set; }
    }

}
