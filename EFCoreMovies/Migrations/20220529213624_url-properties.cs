using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class urlproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImdbURL",
                schema: "mov",
                table: "Movies",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramURL",
                schema: "mov",
                table: "Actors",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterURL",
                schema: "mov",
                table: "Actors",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbURL",
                schema: "mov",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "InstagramURL",
                schema: "mov",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "TwitterURL",
                schema: "mov",
                table: "Actors");
        }
    }
}
