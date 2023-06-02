using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelationalTablesUpdateError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpell_Ability_AbilityId",
                table: "CharacterSpell");

            migrationBuilder.RenameColumn(
                name: "AbilityId",
                table: "CharacterSpell",
                newName: "SpellId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterSpell_AbilityId",
                table: "CharacterSpell",
                newName: "IX_CharacterSpell_SpellId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpell_Spell_SpellId",
                table: "CharacterSpell",
                column: "SpellId",
                principalTable: "Spell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpell_Spell_SpellId",
                table: "CharacterSpell");

            migrationBuilder.RenameColumn(
                name: "SpellId",
                table: "CharacterSpell",
                newName: "AbilityId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterSpell_SpellId",
                table: "CharacterSpell",
                newName: "IX_CharacterSpell_AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpell_Ability_AbilityId",
                table: "CharacterSpell",
                column: "AbilityId",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
