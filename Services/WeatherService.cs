using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Instrukcja.Data;
using Instrukcja.Model;
using Instrukcja.Components.Pages;

namespace Instrukcja.Services //wszystkie metody służące do zapisu, updatu i usuwania danych z bazy dancyh
{
    public class WeatherService
    {
        private readonly WeatherDbContext _context;

        public WeatherService(WeatherDbContext context)
        {
            _context = context;
        }

        // Metody dla WeatherDaily
        public async Task<List<WeatherDaily>> GetAllWeatherDailiesAsync()
        {
            return await _context.WeatherData.ToListAsync();
        }

        //ta funkcja działa tak, że wyszukuje w bazie danych rekord, który ma takie same pole DateDaily  jak rekord, który chcemy dodać do bazy danych
        //jeżeli znajdzie taki rekord to zamiast dodawać rekord to aktualizuje obecny. Jeżeli nie znajdzie to dodaje nowy rekord weather
        public async Task UpdateOrAddWeatherDailyAsync(WeatherDaily weather)
        {
            var existingWeather = await _context.WeatherData
                .Include(w => w.Temp)
                .Include(w => w.Feels_like)
                .Include(w => w.Weather)
                .Include(w => w.WeatherHourlies)
                .FirstOrDefaultAsync(w => w.DateDaily == weather.DateDaily);

            if (existingWeather != null)
            {
                Console.WriteLine($"Updating existing WeatherDaily for date: {weather.DateDaily}");

                // Aktualizacja zwykłych właściwości bez kluczy
                existingWeather.Clouds = weather.Clouds;
                existingWeather.Dew_point = weather.Dew_point;
                existingWeather.Dt = weather.Dt;
                existingWeather.Humidity = weather.Humidity;
                existingWeather.LocationName = weather.LocationName;
                existingWeather.Moon_phase = weather.Moon_phase;
                existingWeather.Moonrise = weather.Moonrise;
                existingWeather.Moonset = weather.Moonset;
                existingWeather.Pop = weather.Pop;
                existingWeather.Pressure = weather.Pressure;
                existingWeather.Sunrise = weather.Sunrise;
                existingWeather.Sunset = weather.Sunset;
                existingWeather.Uvi = weather.Uvi;
                existingWeather.Wind_deg = weather.Wind_deg;
                existingWeather.Wind_gust = weather.Wind_gust;
                existingWeather.Wind_speed = weather.Wind_speed;

                // Aktualizacja powiązanych encji
                if (existingWeather.Temp != null)
                {
                    existingWeather.Temp.Day = weather.Temp.Day;
                    existingWeather.Temp.Eve = weather.Temp.Eve;
                    existingWeather.Temp.Max = weather.Temp.Max;
                    existingWeather.Temp.Min = weather.Temp.Min;
                    existingWeather.Temp.Morn = weather.Temp.Morn;
                    existingWeather.Temp.Night = weather.Temp.Night;
                }
                else
                {
                    existingWeather.Temp = weather.Temp;
                }

                if (existingWeather.Feels_like != null)
                {
                    existingWeather.Feels_like.Day = weather.Feels_like.Day;
                    existingWeather.Feels_like.Eve = weather.Feels_like.Eve;
                    existingWeather.Feels_like.Max = weather.Feels_like.Max;
                    existingWeather.Feels_like.Min = weather.Feels_like.Min;
                    existingWeather.Feels_like.Morn = weather.Feels_like.Morn;
                    existingWeather.Feels_like.Night = weather.Feels_like.Night;
                }
                else
                {
                    existingWeather.Feels_like = weather.Feels_like;
                }

                if (existingWeather.Weather != null && existingWeather.Weather.Count > 0)
                {
                    for (int i = 0; i < existingWeather.Weather.Count; i++)
                    {
                        existingWeather.Weather[i].Main = weather.Weather[i].Main;
                        existingWeather.Weather[i].Description = weather.Weather[i].Description;
                        existingWeather.Weather[i].Icon = weather.Weather[i].Icon;
                    }
                }
                else
                {
                    existingWeather.Weather = weather.Weather;
                }

                // WeatherHourlies będą aktualizowane w oddzielnej metodzie UpdateOrAddWeatherHourlyAsync

                _context.WeatherData.Update(existingWeather);
            }
            else
            {
                Console.WriteLine($"Adding new WeatherDaily for date: {weather.DateDaily}");
                _context.WeatherData.Add(weather);
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteWeatherDailyAsync(WeatherDaily weather)
        {
            _context.WeatherData.Remove(weather);
            await _context.SaveChangesAsync();
        }

        // Metody dla WeatherHourly
        public async Task<List<Model.WeatherHourly>> GetAllWeatherHourliesAsync()
        {
            return await _context.WeatherHourlyData.ToListAsync();
        }

        //ta funkcja działa tak, że wyszukuje w bazie danych rekord, który ma takie same pola DateHourly oraz Time jak rekord, który chcemy dodać do bazy danych
        //jeżeli znajdzie taki rekord to zamiast dodawać rekord to aktualizuje obecny. Jeżeli nie znajdzie to dodaje nowy rekord weatherHourly
        public async Task UpdateOrAddWeatherHourlyAsync(Model.WeatherHourly weatherHourly)
        {
            var existingWeather = await _context.WeatherHourlyData
                .Include(w => w.Weather)
                .FirstOrDefaultAsync(w => w.DateHourly == weatherHourly.DateHourly && w.Time == weatherHourly.Time);

            if (existingWeather != null)
            {
                Console.WriteLine($"Updating existing WeatherHourly for date: {weatherHourly.DateHourly} and time: {weatherHourly.Time}");

                // Aktualizacja zwykłych właściwości bez kluczy
                existingWeather.Clouds = weatherHourly.Clouds;
                existingWeather.Dew_point = weatherHourly.Dew_point;
                existingWeather.Dt = weatherHourly.Dt;
                existingWeather.Humidity = weatherHourly.Humidity;
                existingWeather.Pop = weatherHourly.Pop;
                existingWeather.Pressure = weatherHourly.Pressure;
                existingWeather.Temp = weatherHourly.Temp;
                existingWeather.Uvi = weatherHourly.Uvi;
                existingWeather.Visibility = weatherHourly.Visibility;
                existingWeather.Wind_deg = weatherHourly.Wind_deg;
                existingWeather.Wind_gust = weatherHourly.Wind_gust;
                existingWeather.Wind_speed = weatherHourly.Wind_speed;

                // Aktualizacja powiązanej encji
                if (existingWeather.Weather != null && existingWeather.Weather.Count > 0)
                {
                    for (int i = 0; i < existingWeather.Weather.Count; i++)
                    {
                        existingWeather.Weather[i].Main = weatherHourly.Weather[i].Main;
                        existingWeather.Weather[i].Description = weatherHourly.Weather[i].Description;
                        existingWeather.Weather[i].Icon = weatherHourly.Weather[i].Icon;
                    }
                }
                else
                {
                    existingWeather.Weather = weatherHourly.Weather;
                }

                _context.WeatherHourlyData.Update(existingWeather);
            }
            else
            {
                Console.WriteLine($"Adding new WeatherHourly for date: {weatherHourly.DateHourly} and time: {weatherHourly.Time}");

                var matchDaily = await _context.WeatherData
                    .FirstOrDefaultAsync(wd => wd.DateDaily.Date == weatherHourly.DateHourly.Date);

                if (matchDaily != null)
                {
                    weatherHourly.WeatherDailyId = matchDaily.Id;
                }
                else
                {
                    throw new Exception("No matching WeatherDaily record found for the given date!");
                }

                _context.WeatherHourlyData.Add(weatherHourly);
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteWeatherHourlyAsync(WeatherHourly weatherHourly)
        {
            _context.WeatherHourlyData.Remove(weatherHourly);
            await _context.SaveChangesAsync();
        }

    }
}
