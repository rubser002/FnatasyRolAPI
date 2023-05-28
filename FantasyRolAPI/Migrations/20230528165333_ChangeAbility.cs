using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAbility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character");

            migrationBuilder.AlterColumn<Guid>(
                name: "BackgroundId",
                table: "Character",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Ability",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character",
                column: "BackgroundId",
                principalTable: "Background",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character");

            migrationBuilder.AlterColumn<Guid>(
                name: "BackgroundId",
                table: "Character",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Ability",
                keyColumn: "Identifier",
                keyValue: null,
                column: "Identifier",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Ability",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Background_BackgroundId",
                table: "Character",
                column: "BackgroundId",
                principalTable: "Background",
                principalColumn: "Id");
        }
    }
}
