using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArmorType",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Item",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Range",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeaponTypes",
                table: "Item",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ArmorType",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Range",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "WeaponTypes",
                table: "Item");
        }
    }
}
