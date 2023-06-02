using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelationalTablesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbility_Character_CharacterId1",
                table: "CharacterAbility");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpell_Character_CharacterId1",
                table: "CharacterSpell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterSpell",
                table: "CharacterSpell");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSpell_CharacterId1",
                table: "CharacterSpell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterAbility",
                table: "CharacterAbility");

            migrationBuilder.DropIndex(
                name: "IX_CharacterAbility_CharacterId1",
                table: "CharacterAbility");

            migrationBuilder.RenameColumn(
                name: "CharacterId1",
                table: "CharacterSpell",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CharacterId1",
                table: "CharacterAbility",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterSpell",
                table: "CharacterSpell",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterAbility",
                table: "CharacterAbility",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpell_CharacterId",
                table: "CharacterSpell",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbility_CharacterId",
                table: "CharacterAbility",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbility_Character_CharacterId",
                table: "CharacterAbility",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpell_Character_CharacterId",
                table: "CharacterSpell",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAbility_Character_CharacterId",
                table: "CharacterAbility");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpell_Character_CharacterId",
                table: "CharacterSpell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterSpell",
                table: "CharacterSpell");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSpell_CharacterId",
                table: "CharacterSpell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterAbility",
                table: "CharacterAbility");

            migrationBuilder.DropIndex(
                name: "IX_CharacterAbility_CharacterId",
                table: "CharacterAbility");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CharacterSpell",
                newName: "CharacterId1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CharacterAbility",
                newName: "CharacterId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterSpell",
                table: "CharacterSpell",
                column: "CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterAbility",
                table: "CharacterAbility",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpell_CharacterId1",
                table: "CharacterSpell",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbility_CharacterId1",
                table: "CharacterAbility",
                column: "CharacterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAbility_Character_CharacterId1",
                table: "CharacterAbility",
                column: "CharacterId1",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpell_Character_CharacterId1",
                table: "CharacterSpell",
                column: "CharacterId1",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
