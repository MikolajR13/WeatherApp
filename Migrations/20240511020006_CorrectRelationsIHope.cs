using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class CorrectRelationsIHope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperatures_FellsId",
                table: "WeatherData");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperatures_Id",
                table: "WeatherData");

            migrationBuilder.RenameColumn(
                name: "FellsId",
                table: "WeatherData",
                newName: "TempId");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherData_FellsId",
                table: "WeatherData",
                newName: "IX_WeatherData_TempId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WeatherData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "FeelsLikeId",
                table: "WeatherData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureFellsId",
                table: "Temperatures",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_FeelsLikeId",
                table: "WeatherData",
                column: "FeelsLikeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Temperatures_FeelsLikeId",
                table: "WeatherData",
                column: "FeelsLikeId",
                principalTable: "Temperatures",
                principalColumn: "TemperatureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherData_Temperatures_TempId",
                table: "WeatherData",
                column: "TempId",
                principalTable: "Temperatures",
                principalColumn: "TemperatureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperatures_FeelsLikeId",
                table: "WeatherData");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherData_Temperatures_TempId",
                table: "WeatherData");

            migrationBuilder.DropIndex(
                name: "IX_WeatherData_FeelsLikeId",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "FeelsLikeId",
                table: "WeatherData");

            migrationBuilder.DropColumn(
                name: "TemperatureFellsId",
                table: "Temperatures");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "WeatherData",
                newName: "FellsId");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherData_TempId",
                table: "WeatherData",
                newName: "IX_WeatherData_FellsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WeatherData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

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
    }
}
