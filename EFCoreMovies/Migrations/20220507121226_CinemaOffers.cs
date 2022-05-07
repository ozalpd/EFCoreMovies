using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class CinemaOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaOffers",
                schema: "mov",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(8,4)", precision: 8, scale: 4, nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaOffers_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalSchema: "mov",
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaOffers_BeginDate",
                schema: "mov",
                table: "CinemaOffers",
                column: "BeginDate");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaOffers_CinemaId",
                schema: "mov",
                table: "CinemaOffers",
                column: "CinemaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaOffers",
                schema: "mov");
        }
    }
}
