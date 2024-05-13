using Microsoft.EntityFrameworkCore;
using Instrukcja.Model;

namespace Instrukcja.Data //Klasa do obsługi bazy danych
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherDaily> WeatherData { get; set; } //inicjalizacja encji WeatherData - To są dane dzienne ( odpowiadające WeatherDaily.cs - taki jest typ nawet tej encji)
        public DbSet<Temperature> Temperatures { get; set; } //inicjalizacja encji Temperatures - To są dane dzienne ( odpowiadające Temperature.cs - taki jest typ nawet tej encji)
        public DbSet<Weather> Weather { get; set; } //inicjalizacja encji Weather - To są dane dzienne ( odpowiadające Weather.cs - taki jest typ nawet tej encji)
        public DbSet<WeatherHourly> WeatherHourlyData { get; set; }  // inicjalizacja encji WeatherHourlyData - To są dane dzienne ( odpowiadające WeatherHourly.cs - taki jest typ nawet tej encji)

        protected override void OnConfiguring(DbContextOptionsBuilder options) //opcjonalne gdyby w appsettings.json coś nie zadziałało
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=weather.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //tworzenie bazy danych
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji jeden do jednego dla Temp
            modelBuilder.Entity<WeatherDaily>()
                .HasOne(w => w.Temp)
                .WithOne()
                .HasForeignKey<WeatherDaily>(w => w.TempId)
                .OnDelete(DeleteBehavior.Cascade);  // Określone zachowanie przy usuwaniu

            // Konfiguracja relacji jeden do jednego dla Feels_like
            modelBuilder.Entity<WeatherDaily>()
                .HasOne(w => w.Feels_like)
                .WithOne()
                .HasForeignKey<WeatherDaily>(w => w.FeelsLikeId)
                .OnDelete(DeleteBehavior.Cascade);  // Określone zachowanie przy usuwaniu

            modelBuilder.Entity<Weather>()
                .HasKey(w => w.Id1);  // Ustawienie Id1 jako klucz główny

            modelBuilder.Entity<Weather>()
                .Property(w => w.Id1)
                .ValueGeneratedOnAdd();  // Konfiguracja autoinkrementacji dla Id1


            // Dodatkowe konfiguracje dla WeatherHourly
            modelBuilder.Entity<WeatherHourly>()
                .HasKey(wh => wh.Id);  // Klucz główny dla WeatherHourly

            modelBuilder.Entity<WeatherHourly>()
                .Property(wh => wh.Id)
                .ValueGeneratedOnAdd();  // Autoinkrementacja dla Id

            //relacja 1 do wielu między WeatherDaily a WeatherHourlyData
            modelBuilder.Entity<WeatherDaily>() 
                .HasMany(wd => wd.WeatherHourlies) //jedna WeatherDaily ma wiele WeatherHourlies
                .WithOne(wh => wh.WeatherDaily)
                .HasForeignKey(wh => wh.WeatherDailyId) //Klucz obcy nadawany ręcznie 
                .OnDelete(DeleteBehavior.Cascade); //co się dzieje przy usuwaniu
            

        }
    }
}
