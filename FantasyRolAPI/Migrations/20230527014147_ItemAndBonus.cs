using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class ItemAndBonus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlignmentId",
                table: "Character");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "Bonus",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_CharacterId",
                table: "Bonus",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bonus_Character_CharacterId",
                table: "Bonus",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonus_Character_CharacterId",
                table: "Bonus");

            migrationBuilder.DropIndex(
                name: "IX_Bonus_CharacterId",
                table: "Bonus");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Bonus");

            migrationBuilder.AddColumn<Guid>(
                name: "AlignmentId",
                table: "Character",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }
    }
}
