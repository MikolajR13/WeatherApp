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
    [Migration("20240512144844_AddedHourlyAndNewService1")]
    partial class AddedHourlyAndNewService1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Instrukcja.Model.Temperature", b =>
                {
                    b.Property<int>("TemperatureId")
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

                    b.Property<int>("TemperatureFellsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TemperatureId");

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("Instrukcja.Model.Weather", b =>
                {
                    b.Property<int>("Id1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Main")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WeatherDailyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeatherDailyId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeatherHourlyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id1");

                    b.HasIndex("WeatherDailyId");

                    b.HasIndex("WeatherDailyId1");

                    b.HasIndex("WeatherHourlyId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherDaily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Clouds")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Dew_point")
                        .HasColumnType("REAL");

                    b.Property<long>("Dt")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FeelsLikeId")
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

                    b.Property<int>("TempId")
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

                    b.HasIndex("FeelsLikeId")
                        .IsUnique();

                    b.HasIndex("TempId")
                        .IsUnique();

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherHourly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Clouds")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Dew_point")
                        .HasColumnType("REAL");

                    b.Property<long>("Dt")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Feels_like")
                        .HasColumnType("REAL");

                    b.Property<int>("Humidity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Pop")
                        .HasColumnType("REAL");

                    b.Property<int>("Pressure")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Temp")
                        .HasColumnType("REAL");

                    b.Property<double>("Uvi")
                        .HasColumnType("REAL");

                    b.Property<int>("Visibility")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wind_deg")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Wind_gust")
                        .HasColumnType("REAL");

                    b.Property<double>("Wind_speed")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("WeatherHourlyData");
                });

            modelBuilder.Entity("Instrukcja.Model.Weather", b =>
                {
                    b.HasOne("Instrukcja.Model.WeatherDaily", null)
                        .WithMany()
                        .HasForeignKey("WeatherDailyId");

                    b.HasOne("Instrukcja.Model.WeatherDaily", null)
                        .WithMany("Weather")
                        .HasForeignKey("WeatherDailyId1");

                    b.HasOne("Instrukcja.Model.WeatherHourly", null)
                        .WithMany("Weather")
                        .HasForeignKey("WeatherHourlyId");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherDaily", b =>
                {
                    b.HasOne("Instrukcja.Model.Temperature", "Feels_like")
                        .WithOne()
                        .HasForeignKey("Instrukcja.Model.WeatherDaily", "FeelsLikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Instrukcja.Model.Temperature", "Temp")
                        .WithOne()
                        .HasForeignKey("Instrukcja.Model.WeatherDaily", "TempId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feels_like");

                    b.Navigation("Temp");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherDaily", b =>
                {
                    b.Navigation("Weather");
                });

            modelBuilder.Entity("Instrukcja.Model.WeatherHourly", b =>
                {
                    b.Navigation("Weather");
                });
#pragma warning restore 612, 618
        }
    }
}
