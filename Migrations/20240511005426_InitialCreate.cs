using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    TemperatureId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<double>(type: "REAL", nullable: false),
                    Min = table.Column<double>(type: "REAL", nullable: false),
                    Max = table.Column<double>(type: "REAL", nullable: false),
                    Night = table.Column<double>(type: "REAL", nullable: false),
                    Eve = table.Column<double>(type: "REAL", nullable: false),
                    Morn = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.TemperatureId);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dt = table.Column<long>(type: "INTEGER", nullable: false),
                    Sunrise = table.Column<long>(type: "INTEGER", nullable: false),
                    Sunset = table.Column<long>(type: "INTEGER", nullable: false),
                    Moonrise = table.Column<long>(type: "INTEGER", nullable: false),
                    Moonset = table.Column<long>(type: "INTEGER", nullable: false),
                    Moon_phase = table.Column<double>(type: "REAL", nullable: false),
                    TemperatureId = table.Column<long>(type: "INTEGER", nullable: false),
                    Feels_likeTemperatureId = table.Column<long>(type: "INTEGER", nullable: false),
                    Pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    Humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    Dew_point = table.Column<double>(type: "REAL", nullable: false),
                    Wind_speed = table.Column<double>(type: "REAL", nullable: false),
                    Wind_gust = table.Column<double>(type: "REAL", nullable: false),
                    Wind_deg = table.Column<int>(type: "INTEGER", nullable: false),
                    Clouds = table.Column<int>(type: "INTEGER", nullable: false),
                    Uvi = table.Column<double>(type: "REAL", nullable: false),
                    Pop = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherData_Temperature_Feels_likeTemperatureId",
                        column: x => x.Feels_likeTemperatureId,
                        principalTable: "Temperature",
                        principalColumn: "TemperatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherData_Temperature_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperature",
                        principalColumn: "TemperatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Main = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    WeatherDailyId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_WeatherData_WeatherDailyId",
                        column: x => x.WeatherDailyId,
                        principalTable: "WeatherData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WeatherDailyId",
                table: "Weather",
                column: "WeatherDailyId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_Feels_likeTemperatureId",
                table: "WeatherData",
                column: "Feels_likeTemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_TemperatureId",
                table: "WeatherData",
                column: "TemperatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "WeatherData");

            migrationBuilder.DropTable(
                name: "Temperature");
        }
    }
}
