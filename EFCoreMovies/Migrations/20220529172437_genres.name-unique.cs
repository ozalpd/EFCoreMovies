using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class genresnameunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                schema: "mov",
                table: "Genres");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                schema: "mov",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "IsDeleted=0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                schema: "mov",
                table: "Genres");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                schema: "mov",
                table: "Genres",
                column: "Name");
        }
    }
}
