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
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)  //zamiana czas z unixowego na DateTime
        {
            // Ustawienie punktu początkowego (epoch)
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            // Dodanie liczby sekund
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public async Task<WeatherDataResult> GetLast10WeatherDailiesWithHourliesAsync() //metoda gdzie pobieramy 10 ostatnich dni, które zostały dodane do bazy dancych 
        {
            // Pobranie ostatnich 10 rekordów z WeatherDaily
            var last10Dailies = await _context.WeatherData
                .Include(wd => wd.Temp) //dodajemy też obiekt Temp, który jest powiązany relacją z naszym WeatherData więc nie musimy się martwić czy się poprawny doda
                .Include(wd => wd.Weather) //Tak samo jak z Temp dodajemy Weather
                .Include(wd => wd.WeatherHourlies)  //Dodajemy również dla każdego dnia powiązane relacją dane godzinowe
                .Take(10)                      // Pobranie ostatnich 10 rekordów
                .ToListAsync(); // i to wszystko do listy leci

            // Lista na wszystkie powiązane rekordy WeatherHourly
            var allHourlies = new List<WeatherHourly>();

            // Dla każdego rekordu WeatherDaily pobierz odpowiednie rekordy WeatherHourly
            foreach (var daily in last10Dailies)  
            {
                var dateOnly = daily.DateDaily;  // Wyciągnięcie daty dla danego dnia ( dlatego to wcześniej było potrzebne)
                var hourliesForDay = await _context.WeatherHourlyData
                    .Where(wh => wh.DateHourly == dateOnly)  // Porównanie tylko daty
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
