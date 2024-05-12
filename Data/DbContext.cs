using Microsoft.EntityFrameworkCore;
using Instrukcja.Model;

namespace Instrukcja.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherDaily> WeatherData { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<WeatherHourly> WeatherHourlyData { get; set; }  // Dodanie nowego DbSet

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=weather.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji jeden do jednego dla Temp
            modelBuilder.Entity<WeatherDaily>()
                .HasOne(w => w.Temp)
                .WithOne()
                .HasForeignKey<WeatherDaily>(w => w.TempId)
                .OnDelete(DeleteBehavior.Cascade);  // Określ zachowanie przy usuwaniu

            // Konfiguracja relacji jeden do jednego dla Feels_like
            modelBuilder.Entity<WeatherDaily>()
                .HasOne(w => w.Feels_like)
                .WithOne()
                .HasForeignKey<WeatherDaily>(w => w.FeelsLikeId)
                .OnDelete(DeleteBehavior.Cascade);  // Określ zachowanie przy usuwaniu

            modelBuilder.Entity<Weather>()
                .HasKey(w => w.Id1);  // Ustawienie Id1 jako klucz główny

            modelBuilder.Entity<Weather>()
                .Property(w => w.Id1)
                .ValueGeneratedOnAdd();  // Konfiguracja autoinkrementacji dla Id1, jeśli jest to potrzebne


            // Dodatkowe konfiguracje dla WeatherHourly
            modelBuilder.Entity<WeatherHourly>()
                .HasKey(wh => wh.Id);  // Klucz główny dla WeatherHourly

            modelBuilder.Entity<WeatherHourly>()
                .Property(wh => wh.Id)
                .ValueGeneratedOnAdd();  // Autoinkrementacja dla Id, jeśli jest to potrzebne

            modelBuilder.Entity<WeatherDaily>()
                .HasMany(wd => wd.WeatherHourlies)
                .WithOne(wh => wh.WeatherDaily)
                .HasForeignKey(wh => wh.WeatherDailyId)
                .OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}
