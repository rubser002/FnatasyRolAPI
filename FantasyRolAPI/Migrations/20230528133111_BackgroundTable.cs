using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class BackgroundTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BackgroundId",
                table: "Character",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Languages = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Features = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalityTrait = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ideal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bond = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Flaw = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Character_BackgroundId",
                table: "Character",
                column: "BackgroundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character",
                column: "BackgroundId",
                principalTable: "Background",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character");

            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropIndex(
                name: "IX_Character_BackgroundId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "BackgroundId",
                table: "Character");
        }
    }
}
