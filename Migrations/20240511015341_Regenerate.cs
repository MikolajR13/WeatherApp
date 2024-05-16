using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class Regenerate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperature_Feels_likeTemperatureId",
                table: "WeatherData");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperature_TemperatureId",
                table: "WeatherData");

            migrationBuilder.DropIndex(
                name: "IX_WeatherData_Feels_likeTemperatureId",
                table: "WeatherData");

            migrationBuilder.DropIndex(
                name: "IX_WeatherData_TemperatureId",
                table: "WeatherData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature");

            migrationBuilder.DropColumn(
                name: "Feels_likeTemperatureId",
                table: "WeatherData");

            migrationBuilder.RenameTable(
                name: "Temperature",
                newName: "Temperatures");

            migrationBuilder.RenameColumn(
                name: "TemperatureId",
                table: "WeatherData",
                newName: "FellsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WeatherData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures",
                column: "TemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_FellsId",
                table: "WeatherData",
                column: "FellsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Temperatures_FellsId",
                table: "WeatherData",
                column: "FellsId",
                principalTable: "Temperatures",
                principalColumn: "TemperatureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Temperatures_Id",
                table: "WeatherData",
                column: "Id",
                principalTable: "Temperatures",
                principalColumn: "TemperatureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperatures_FellsId",
                table: "WeatherData");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperatures_Id",
                table: "WeatherData");

            migrationBuilder.DropIndex(
                name: "IX_WeatherData_FellsId",
                table: "WeatherData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures");

            migrationBuilder.RenameTable(
                name: "Temperatures",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "FellsId",
                table: "WeatherData",
                newName: "TemperatureId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "WeatherData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<long>(
                name: "Feels_likeTemperatureId",
                table: "WeatherData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperature",
                table: "Temperature",
                column: "TemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_Feels_likeTemperatureId",
                table: "WeatherData",
                column: "Feels_likeTemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_TemperatureId",
                table: "WeatherData",
                column: "TemperatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Temperature_Feels_likeTemperatureId",
                table: "WeatherData",
                column: "Feels_likeTemperatureId",
                principalTable: "Temperature",
                principalColumn: "TemperatureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Temperature_TemperatureId",
                table: "WeatherData",
                column: "TemperatureId",
                principalTable: "Temperature",
                principalColumn: "TemperatureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
