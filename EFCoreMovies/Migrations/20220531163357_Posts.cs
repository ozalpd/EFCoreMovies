using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class Posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "soc");

            migrationBuilder.CreateTable(
                name: "People",
                schema: "soc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "soc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ParentPostId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_People_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "soc",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Posts_ParentPostId",
                        column: x => x.ParentPostId,
                        principalSchema: "soc",
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "soc",
                table: "People",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ozge" },
                    { 2, "Lone Wolf" },
                    { 3, "Shebnem" },
                    { 4, "Nurettin" }
                });

            migrationBuilder.InsertData(
                schema: "soc",
                table: "Posts",
                columns: new[] { "Id", "Body", "ParentPostId", "SenderId", "Subject" },
                values: new object[,]
                {
                    { 1, "When Arwen and Aragorn met first time Aragorn was 20 and Arwen was 2710 years old. Don't you think they felt generational gap between each others? How could they handle it?", null, 1, "Arwen and Aragorn" },
                    { 3, "Hello I'm new around here.", null, 4, "Hello" },
                    { 4, "Hello, I'm looking for discount coupons for Top Gun 2 movie. Anyone can help me?", null, 2, "Coupons" },
                    { 5, "I googled two hours ago, couldn't find any :-(", null, 3, "Re:Coupons" }
                });

            migrationBuilder.InsertData(
                schema: "soc",
                table: "Posts",
                columns: new[] { "Id", "Body", "ParentPostId", "SenderId", "Subject" },
                values: new object[] { 2, "Aragorn had wisdom of thousands years so they should felt as they were in same generation.", 1, 2, "Re: Arwen and Aragorn" });

            migrationBuilder.InsertData(
                schema: "soc",
                table: "Posts",
                columns: new[] { "Id", "Body", "ParentPostId", "SenderId", "Subject" },
                values: new object[] { 6, "They are fictious characters of Tolkien. I don't think he used this level of complex details in his fictions.", 2, 3, "Re: Arwen and Aragorn" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ParentPostId",
                schema: "soc",
                table: "Posts",
                column: "ParentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SenderId",
                schema: "soc",
                table: "Posts",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Subject",
                schema: "soc",
                table: "Posts",
                column: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts",
                schema: "soc");

            migrationBuilder.DropTable(
                name: "People",
                schema: "soc");
        }
    }
}
