using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAbilitiesClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAbility_Class_ClassId1",
                table: "ClassAbility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassAbility",
                table: "ClassAbility");

            migrationBuilder.DropIndex(
                name: "IX_ClassAbility_ClassId1",
                table: "ClassAbility");

            migrationBuilder.RenameColumn(
                name: "ClassId1",
                table: "ClassAbility",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassAbility",
                table: "ClassAbility",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAbility_ClassId",
                table: "ClassAbility",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAbility_Class_ClassId",
                table: "ClassAbility",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAbility_Class_ClassId",
                table: "ClassAbility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassAbility",
                table: "ClassAbility");

            migrationBuilder.DropIndex(
                name: "IX_ClassAbility_ClassId",
                table: "ClassAbility");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ClassAbility",
                newName: "ClassId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassAbility",
                table: "ClassAbility",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAbility_ClassId1",
                table: "ClassAbility",
                column: "ClassId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAbility_Class_ClassId1",
                table: "ClassAbility",
                column: "ClassId1",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
