using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Instrukcja.Data;
using Instrukcja.Model;

namespace Instrukcja.Services
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

        public async Task AddWeatherDailyAsync(WeatherDaily weather)
        {
            _context.WeatherData.Add(weather);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWeatherDailyAsync(WeatherDaily weather)
        {
            _context.WeatherData.Update(weather);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWeatherDailyAsync(WeatherDaily weather)
        {
            _context.WeatherData.Remove(weather);
            await _context.SaveChangesAsync();
        }

        // Metody dla WeatherHourly
        public async Task<List<WeatherHourly>> GetAllWeatherHourliesAsync()
        {
            return await _context.WeatherHourlyData.ToListAsync();
        }

        public async Task AddWeatherHourlyAsync(WeatherHourly weatherHourly)
        {
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
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWeatherHourlyAsync(WeatherHourly weatherHourly)
        {
            _context.WeatherHourlyData.Update(weatherHourly);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWeatherHourlyAsync(WeatherHourly weatherHourly)
        {
            _context.WeatherHourlyData.Remove(weatherHourly);
            await _context.SaveChangesAsync();
        }

    }
}
