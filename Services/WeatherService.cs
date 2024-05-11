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

        public async Task<List<WeatherDaily>> GetAllWeatherAsync()
        {
            return await _context.WeatherData.ToListAsync();
        }

        public async Task AddWeatherAsync(WeatherDaily weather)
        {
            _context.WeatherData.Add(weather);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWeatherAsync(WeatherDaily weather)
        {
            _context.WeatherData.Update(weather);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWeatherAsync(WeatherDaily weather)
        {
            _context.WeatherData.Remove(weather);
            await _context.SaveChangesAsync();
        }
    }
}
