using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class AddedHourlyAndNewService3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId",
                table: "Weather");

            migrationBuilder.DropForeignKey(
                name: "FK_Weather_WeatherHourlyData_WeatherHourlyId",
                table: "Weather");

            migrationBuilder.AlterColumn<int>(
                name: "WeatherHourlyId",
                table: "Weather",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "WeatherDailyId",
                table: "Weather",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_WeatherData_WeatherDailyId",
                table: "Weather",
                column: "WeatherDailyId",
                principalTable: "WeatherData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weather_WeatherHourlyData_WeatherHourlyId",
                table: "Weather",
                column: "WeatherHourlyId",
                principalTable: "WeatherHourlyData",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<int>(
                name: "WeatherHourlyId",
                table: "Weather",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeatherDailyId",
                table: "Weather",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
    }
}
