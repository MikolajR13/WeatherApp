using Instrukcja.Model;
using Microsoft.EntityFrameworkCore;
using Instrukcja.Data;
using Instrukcja.Services;

namespace Instrukcja.Services //serwis, w którym odczytujemy dane z bazy danych
{
    public class ReadDataBaseService
    {
        private readonly WeatherDbContext _context;

        public ReadDataBaseService(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<(List<double> Temperatures, List<(double Min, double Max)> MinMaxTemperatues, List<string> Data, List<double> SelectedData,  List<double> FeelsLikeTemperature)> 
            GetWeatherDataFromDataBase(string inputDataType, string location, bool isHourly = false)
        {
            if(isHourly) 
            {
                var weatherHourlies = await _context.WeatherHourlyData
                    .Include(wh => wh.WeatherDaily)
                    .Where(wh => wh.LocationName == location)
                    .OrderBy(wh => wh.DateHourly)
                    .ThenBy(wh => wh.Time)
                    .Take(48)
                    .ToListAsync();

                var Temperatures = new List<double>();
                var MinMaxTemperatues = new List<(double Min, double Max)>();
                var Data = new List<string>();
                var SelectedData = new List<double>();
                var FeelsLikeTemperature = new List<double>();

                foreach(var wh in weatherHourlies)
                {
                    Temperatures.Add(wh.Temp);
                    Console.WriteLine(Temperatures);
                    Data.Add($"{wh.DateHourly.ToShortDateString()} {wh.Time}");
                    Console.WriteLine(Data);

                    // public List<string> inputTypeOfData = new List<string> {"Temperatura", "Zachmurzenie", "Prędkość Wiatru", "Ciśnienie Atmosferyczne", "Wilgotność powietrza", "Prawdopodobieństwo opadów" };


                    double value = inputDataType switch
                    {
                        "Temperatura" => wh.Temp,
                        "Zachmurzenie" => wh.Clouds,
                        "Prędkość Wiatru" => wh.Wind_speed,
                        "Ciśnienie Atmosferyczne" => wh.Pressure,
                        "Wilgotność Powietrza" => wh.Humidity,
                        "Prawdopodobieństwo Opadów" => wh.Pop,
                        _ => wh.Pop
                    };

                    SelectedData.Add(value);
                    Console.WriteLine(SelectedData);
                    FeelsLikeTemperature.Add(wh.Feels_like);
                    Console.WriteLine(FeelsLikeTemperature);
                    MinMaxTemperatues.Add((wh.Wind_gust, wh.Wind_gust)); //useless, nie potrzebujemy tego wyjebane musiałem coś wpisać żeby działało xd
                }
                return (Temperatures, MinMaxTemperatues, Data, SelectedData, FeelsLikeTemperature);
            
            }
            else
            {
                var weatherDailies = await _context.WeatherData
                    .Include(wd => wd.Temp)
                    .Include(wd => wd.Feels_like)
                    .Include(wd => wd.Weather)
                    .Where(wd => wd.LocationName == location)
                    .OrderBy(wd => wd.DateDaily)
                    .Take(8)
                    .ToListAsync();

                var Temperatures = new List<double>();
                var MinMaxTemperatues = new List<(double Min, double Max)>();
                var Data = new List<string>();
                var SelectedData = new List<double>();
                var FeelsLikeTemperature = new List<double>();

                foreach(var wd in weatherDailies)
                {
                    Temperatures.Add(wd.Temp.Morn);
                    Temperatures.Add(wd.Temp.Day);
                    Temperatures.Add(wd.Temp.Eve);
                    Temperatures.Add(wd.Temp.Night);
                    MinMaxTemperatues.Add((wd.Temp.Min, wd.Temp.Max));
                    Data.Add(wd.DateDaily.ToShortDateString());
                    
                    double value = inputDataType switch
                {
                    "Temperatura" => wd.Temp.Day,
                    "Zachmurzenie" => wd.Clouds,
                    "Prędkość Wiatru" => wd.Wind_speed,
                    "Ciśnienie Atmosferyczne" => wd.Pressure,
                    "Wilgotność Powietrza" => wd.Humidity,
                    "Prawdopodobieństwo Opadów" => wd.Pop,
                    _ => wd.Pop
                };

                    SelectedData.Add(value);
                    FeelsLikeTemperature.Add(wd.Feels_like.Morn);
                    FeelsLikeTemperature.Add(wd.Feels_like.Day);
                    FeelsLikeTemperature.Add(wd.Feels_like.Eve);
                    FeelsLikeTemperature.Add(wd.Feels_like.Night);

                }

                return (Temperatures, MinMaxTemperatues, Data, SelectedData, FeelsLikeTemperature);
            }
        }

    }
}
