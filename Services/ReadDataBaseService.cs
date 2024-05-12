using Instrukcja.Model;
using Microsoft.EntityFrameworkCore;
using Instrukcja.Data;
using Instrukcja.Services;

namespace Instrukcja.Services
{
    public class ReadDataBaseService
    {
        private readonly WeatherDbContext _context;

        public ReadDataBaseService(WeatherDbContext context)
        {
            _context = context;
        }
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Ustawienie punktu początkowego (epoch)
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            // Dodanie liczby sekund
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public async Task<WeatherDataResult> GetLast10WeatherDailiesWithHourliesAsync()
        {
            // Pobranie ostatnich 10 rekordów z WeatherDaily
            var last10Dailies = await _context.WeatherData
                .OrderByDescending(w => w.Dt)  // Sortowanie malejąco po dacie
                .Take(10)                      // Pobranie ostatnich 10 rekordów
                .ToListAsync();

            // Lista na wszystkie powiązane rekordy WeatherHourly
            var allHourlies = new List<WeatherHourly>();

            // Dla każdego rekordu WeatherDaily pobierz odpowiednie rekordy WeatherHourly
            foreach (var daily in last10Dailies)
            {
                var dateOnly = UnixTimeStampToDateTime(daily.Dt).Date;  // Konwersja na DateTime i wyciągnięcie daty
                var hourliesForDay = await _context.WeatherHourlyData
                    .Where(wh => UnixTimeStampToDateTime(wh.Dt).Date == dateOnly)  // Porównanie tylko daty
                    .OrderBy(wh => wh.Dt)  // Opcjonalne sortowanie po dacie
                    .Take(24)  // Pobranie do 24 rekordów
                    .ToListAsync();

                allHourlies.AddRange(hourliesForDay);  // Dodajemy do głównej listy
            }

            return new WeatherDataResult
            {
                DailiesData = last10Dailies,
                HourliesData = allHourlies
            };
        }

    }
}
