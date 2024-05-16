﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class AddedHourlyAndNewService2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId",
                table: "Weather");

            migrationBuilder.DropForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId1",
                table: "Weather");

            migrationBuilder.DropForeignKey(
                name: "FK_Weather_WeatherHourlyData_WeatherHourlyId",
                table: "Weather");

            migrationBuilder.DropIndex(
                name: "IX_Weather_WeatherDailyId1",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "WeatherDailyId1",
                table: "Weather");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId",
                table: "Weather",
                column: "WeatherDailyId",
                principalTable: "WeatherData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_WeatherHourlyData_WeatherHourlyId",
                table: "Weather",
                column: "WeatherHourlyId",
                principalTable: "WeatherHourlyData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId",
                table: "Weather");

            migrationBuilder.DropForeignKey(
                name: "FK_Weather_WeatherHourlyData_WeatherHourlyId",
                table: "Weather");

            migrationBuilder.AddColumn<int>(
                name: "WeatherDailyId1",
                table: "Weather",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WeatherDailyId1",
                table: "Weather",
                column: "WeatherDailyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId",
                table: "Weather",
                column: "WeatherDailyId",
                principalTable: "WeatherData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId1",
                table: "Weather",
                column: "WeatherDailyId1",
                principalTable: "WeatherData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_WeatherHourlyData_WeatherHourlyId",
                table: "Weather",
                column: "WeatherHourlyId",
                principalTable: "WeatherHourlyData",
                principalColumn: "Id");
        }
    }
}
