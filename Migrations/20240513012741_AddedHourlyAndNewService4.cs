using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class AddedHourlyAndNewService4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateHourly",
                table: "WeatherHourlyData",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "WeatherHourlyData",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "WeatherDailyId",
                table: "WeatherHourlyData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDaily",
                table: "WeatherData",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_WeatherHourlyData_WeatherDailyId",
                table: "WeatherHourlyData",
                column: "WeatherDailyId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherHourlyData_WeatherData_WeatherDailyId",
                table: "WeatherHourlyData",
                column: "WeatherDailyId",
                principalTable: "WeatherData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherHourlyData_WeatherData_WeatherDailyId",
                table: "WeatherHourlyData");

            migrationBuilder.DropIndex(
                name: "IX_WeatherHourlyData_WeatherDailyId",
                table: "WeatherHourlyData");

            migrationBuilder.DropColumn(
                name: "DateHourly",
                table: "WeatherHourlyData");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "WeatherHourlyData");

            migrationBuilder.DropColumn(
                name: "WeatherDailyId",
                table: "WeatherHourlyData");

            migrationBuilder.DropColumn(
                name: "DateDaily",
                table: "WeatherData");
        }
    }
}
