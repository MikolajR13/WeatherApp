﻿// <auto-generated />
using System;
using Instrukcja.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Instrukcja.Migrations
{
    [DbContext(typeof(WeatherDbContext))]
    [Migration("20240511005426_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Instrukcja.Model.Temperature", b =>
                {
                    b.Property<long>("TemperatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Day")
                        .HasColumnType("REAL");

                    b.Property<double>("Eve")
                        .HasColumnType("REAL");

                    b.Property<double>("Max")
                        .HasColumnType("REAL");

                    b.Property<double>("Min")
                        .HasColumnType("REAL");

                    b.Property<double>("Morn")
                        .HasColumnType("REAL");

                    b.Property<double>("Night")
                        .HasColumnType("REAL");

                    b.HasKey("TemperatureId");

                    b.ToTable("Temperature");
                });

            modelBuilder.Entity("Instrukcja.Model.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Main")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("WeatherDailyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDailyId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherDaily", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Clouds")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Dew_point")
                        .HasColumnType("REAL");

                    b.Property<long>("Dt")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Feels_likeTemperatureId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Humidity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Moon_phase")
                        .HasColumnType("REAL");

                    b.Property<long>("Moonrise")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Moonset")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Pop")
                        .HasColumnType("REAL");

                    b.Property<int>("Pressure")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Sunrise")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Sunset")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TemperatureId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Uvi")
                        .HasColumnType("REAL");

                    b.Property<int>("Wind_deg")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Wind_gust")
                        .HasColumnType("REAL");

                    b.Property<double>("Wind_speed")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("Feels_likeTemperatureId");

                    b.HasIndex("TemperatureId");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("Instrukcja.Model.Weather", b =>
                {
                    b.HasOne("Instrukcja.Model.WeatherDaily", null)
                        .WithMany("Weather")
                        .HasForeignKey("WeatherDailyId");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherDaily", b =>
                {
                    b.HasOne("Instrukcja.Model.Temperature", "Feels_like")
                        .WithMany()
                        .HasForeignKey("Feels_likeTemperatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Instrukcja.Model.Temperature", "Temp")
                        .WithMany()
                        .HasForeignKey("TemperatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feels_like");

                    b.Navigation("Temp");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherDaily", b =>
                {
                    b.Navigation("Weather");
                });
#pragma warning restore 612, 618
        }
    }
}
