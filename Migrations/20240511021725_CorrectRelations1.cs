using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instrukcja.Migrations
{
    /// <inheritdoc />
    public partial class CorrectRelations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Weather",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id1",
                table: "Weather",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                column: "Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "Id1",
                table: "Weather");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Weather",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                column: "Id");
        }
    }
}
