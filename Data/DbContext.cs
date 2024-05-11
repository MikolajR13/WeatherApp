using Microsoft.EntityFrameworkCore;
using Instrukcja.Model;

namespace Instrukcja.Data
{
    public class WeatherDbContext : DbContext
    {
        // Konstruktor przyjmujący opcje DbContext, które mogą być wstrzyknięte
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherDaily> WeatherData { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }  // Załóżmy, że Temperature jest również encją

        // Opcjonalnie, zachowaj metodę OnConfiguring dla dodatkowej konfiguracji lub fallbacku
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Tylko jeśli nie przekazano żadnych opcji (Options nie zawiera już skonfigurowanego dostawcy)
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=weather.db");
            }
        }

        // Konfiguracja modelu i relacji między tabelami
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
        }
    }
    }

