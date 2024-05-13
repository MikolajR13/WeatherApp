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
                .Include(w => w.Temp) //uwzględnianie Temp żeby ręcznie je zaktualizować, wpp będą nam się rekordy duplikowały
                .Include(w => w.Feels_like) //to samo co u góry
                .Include(w => w.Weather) // to samo co u góry
                .FirstOrDefaultAsync(w => w.DateDaily == weather.DateDaily);
            if (existingWeather != null) // jeżeli nie jest pusty to 
            {
                _context.Entry(existingWeather).CurrentValues.SetValues(weather); //wszystkie normalne pola updatujemy ( czyli int string itp itd)
                if(existingWeather.Temp !=null) //sprawdzamy czy jest Temp jakieś i jezeli jest to
                {
                    _context.Entry(existingWeather.Temp).CurrentValues.SetValues(weather.Temp); //ręcznie robimy update
                }
                else // jeżeli nie to dodajemy nowe Temp
                {
                    existingWeather.Temp = weather.Temp;
                }
                if(existingWeather.Feels_like != null) //to samo co dla Temp
                {
                    _context.Entry(existingWeather.Feels_like).CurrentValues.SetValues(weather.Feels_like);
                }
                else
                {
                    existingWeather.Feels_like = weather.Feels_like;
                }
                if(existingWeather.Weather != null) //To samo co dla Temp
                {
                    _context.Entry(existingWeather.Weather).CurrentValues.SetValues(weather.Weather);
                }
                else
                {
                    existingWeather.Weather = weather.Weather;
                }
                if(existingWeather.WeatherHourlies != null) //To samo co dla Temp
                {
                    _context.Entry(existingWeather.WeatherHourlies).CurrentValues.SetValues(weather.WeatherHourlies);
                }
                else
                {
                    existingWeather.WeatherHourlies = weather.WeatherHourlies;
                }
                           
                _context.WeatherData.Update(existingWeather); //update
            }
            else
            {
                _context.WeatherData.Add(weather); //lub dodanie jeżeli nie znaleźliśmy rekordu
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
            //wyszukiwanie czy jest rekord o takiej samej DateHourly oraz Time
            var existingWeather = await _context.WeatherHourlyData
                .Include(w => w.Weather) //uwzględniamy Weather bo jeżeli tego nie zrobimy to będą nam się duplikowały rekordy
                .FirstOrDefaultAsync(w => w.DateHourly == weatherHourly.DateHourly && w.Time == weatherHourly.Time);
            if (existingWeather != null) { //jeżeli istnieje już taki rekord

                _context.Entry(existingWeather).CurrentValues.SetValues(weatherHourly); //update wszystkich normalnych pól ( typu int, string, date time itp itd)
                if(existingWeather.Weather != null) //jeżeli Weather nie jest puste 
                {
                    _context.Entry(existingWeather.Weather).CurrentValues.SetValues(weatherHourly); //update Weather
                }
                else //jeżeli jest puste to dodajemy
                {
                    existingWeather.Weather = weatherHourly.Weather;
                }

                _context.WeatherHourlyData.Update(existingWeather); //update
            }
            else //jeżeli nie ma jeszcze takiego rekordu co ma taką samą datę i godzinę to 
            {   // WAŻNE - nadawanie klucza obcego w obiekcie weatherHourly - szukamy dnia, który ma taki sam dzień i przypisujemy obiektowi weatherHourly klucz pomocniczy weatherHourly.WeatherDailyId = WeatherDaily.Id 
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
                    _context.WeatherHourlyData.Add(weatherHourly); //dodanie nowego rekordu
            }
             
            await _context.SaveChangesAsync();  //save
        }

        public async Task DeleteWeatherHourlyAsync(WeatherHourly weatherHourly)
        {
            _context.WeatherHourlyData.Remove(weatherHourly);
            await _context.SaveChangesAsync();
        }

    }
}
