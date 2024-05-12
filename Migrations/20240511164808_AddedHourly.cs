using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class AddedHourly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeatherHourlyId",
                table: "Weather",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WeatherHourlyData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dt = table.Column<long>(type: "INTEGER", nullable: false),
                    Temp = table.Column<double>(type: "REAL", nullable: false),
                    Feels_like = table.Column<double>(type: "REAL", nullable: false),
                    Pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    Humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    Dew_point = table.Column<double>(type: "REAL", nullable: false),
                    Uvi = table.Column<double>(type: "REAL", nullable: false),
                    Clouds = table.Column<int>(type: "INTEGER", nullable: false),
                    Visibility = table.Column<int>(type: "INTEGER", nullable: false),
                    Wind_speed = table.Column<double>(type: "REAL", nullable: false),
                    Wind_gust = table.Column<double>(type: "REAL", nullable: false),
                    Wind_deg = table.Column<int>(type: "INTEGER", nullable: false),
                    Pop = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherHourlyData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WeatherHourlyId",
                table: "Weather",
                column: "WeatherHourlyId");

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
                name: "FK_Weather_WeatherHourlyData_WeatherHourlyId",
                table: "Weather");

            migrationBuilder.DropTable(
                name: "WeatherHourlyData");

            migrationBuilder.DropIndex(
                name: "IX_Weather_WeatherHourlyId",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "WeatherHourlyId",
                table: "Weather");
        }
    }
}
