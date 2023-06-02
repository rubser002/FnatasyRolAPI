using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyRolAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ability_Character_CharacterId",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability_Class_ClassId",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Class_CharacterClassId1",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Race_CharacterRaceId1",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Subclass_SubclassId1",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_CharacterClassId1",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_CharacterRaceId1",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_SubclassId1",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Ability_CharacterId",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_ClassId",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "CharacterClassId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "CharacterRaceId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "SubclassId1",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Ability");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubclassId",
                table: "Character",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacterRaceId",
                table: "Character",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacterClassId",
                table: "Character",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlignmentId",
                table: "Character",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterAbility",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CharacterId1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AbilityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAbility", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_CharacterAbility_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAbility_Character_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterSpell",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CharacterId1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AbilityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpell", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_CharacterSpell_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSpell_Character_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassAbility",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClassId1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AbilityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAbility", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_ClassAbility_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAbility_Class_ClassId1",
                        column: x => x.ClassId1,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterClassId",
                table: "Character",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterRaceId",
                table: "Character",
                column: "CharacterRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_SubclassId",
                table: "Character",
                column: "SubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbility_AbilityId",
                table: "CharacterAbility",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbility_CharacterId1",
                table: "CharacterAbility",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpell_AbilityId",
                table: "CharacterSpell",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpell_CharacterId1",
                table: "CharacterSpell",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAbility_AbilityId",
                table: "ClassAbility",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAbility_ClassId1",
                table: "ClassAbility",
                column: "ClassId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Class_CharacterClassId",
                table: "Character",
                column: "CharacterClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Race_CharacterRaceId",
                table: "Character",
                column: "CharacterRaceId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Subclass_SubclassId",
                table: "Character",
                column: "SubclassId",
                principalTable: "Subclass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Class_CharacterClassId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Race_CharacterRaceId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Subclass_SubclassId",
                table: "Character");

            migrationBuilder.DropTable(
                name: "CharacterAbility");

            migrationBuilder.DropTable(
                name: "CharacterSpell");

            migrationBuilder.DropTable(
                name: "ClassAbility");

            migrationBuilder.DropIndex(
                name: "IX_Character_CharacterClassId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_CharacterRaceId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_SubclassId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "SubclassId",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterRaceId",
                table: "Character",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterClassId",
                table: "Character",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "AlignmentId",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterClassId1",
                table: "Character",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterRaceId1",
                table: "Character",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SubclassId1",
                table: "Character",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "Ability",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Ability",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterClassId1",
                table: "Character",
                column: "CharacterClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharacterRaceId1",
                table: "Character",
                column: "CharacterRaceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Character_SubclassId1",
                table: "Character",
                column: "SubclassId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_CharacterId",
                table: "Ability",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_ClassId",
                table: "Ability",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_Character_CharacterId",
                table: "Ability",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_Class_ClassId",
                table: "Ability",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Class_CharacterClassId1",
                table: "Character",
                column: "CharacterClassId1",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Race_CharacterRaceId1",
                table: "Character",
                column: "CharacterRaceId1",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Subclass_SubclassId1",
                table: "Character",
                column: "SubclassId1",
                principalTable: "Subclass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
