using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class CharacterUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Subclass_SubclassId",
                table: "Character");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubclassId",
                table: "Character",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Story",
                table: "Character",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Character",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentSpellSlots",
                table: "Character",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentHitPoints",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Character",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Subclass_SubclassId",
                table: "Character",
                column: "SubclassId",
                principalTable: "Subclass",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Subclass_SubclassId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_UserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Character");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubclassId",
                table: "Character",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Story",
                keyValue: null,
                column: "Story",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Story",
                table: "Character",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Character",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "CurrentSpellSlots",
                keyValue: null,
                column: "CurrentSpellSlots",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentSpellSlots",
                table: "Character",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentHitPoints",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Subclass_SubclassId",
                table: "Character",
                column: "SubclassId",
                principalTable: "Subclass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
