using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameDatabase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dex = table.Column<int>(type: "integer", nullable: false),
                    Str = table.Column<int>(type: "integer", nullable: false),
                    Int = table.Column<int>(type: "integer", nullable: false),
                    End = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreaturePrototypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AttributesId = table.Column<int>(type: "integer", nullable: true),
                    ProgramName = table.Column<string>(type: "text", nullable: true),
                    HitPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreaturePrototypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreaturePrototypes_Attributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "Attributes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbilityPrototypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreaturePrototypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ProgramName = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    PossibleTargets = table.Column<int[]>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityPrototypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityPrototypes_CreaturePrototypes_CreaturePrototypeId",
                        column: x => x.CreaturePrototypeId,
                        principalTable: "CreaturePrototypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemPrototypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreaturePrototypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ProgramName = table.Column<string>(type: "text", nullable: true),
                    AttributesId = table.Column<int>(type: "integer", nullable: true),
                    Rarity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrototypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPrototypes_Attributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "Attributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemPrototypes_CreaturePrototypes_CreaturePrototypeId",
                        column: x => x.CreaturePrototypeId,
                        principalTable: "CreaturePrototypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MaxOnCharacter = table.Column<int>(type: "integer", nullable: false),
                    ProgramName = table.Column<string>(type: "text", nullable: true),
                    CreaturePrototypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemType_CreaturePrototypes_CreaturePrototypeId",
                        column: x => x.CreaturePrototypeId,
                        principalTable: "CreaturePrototypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModifierPrototypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AbilityPrototypeId = table.Column<int>(type: "integer", nullable: true),
                    CreaturePrototypeId = table.Column<int>(type: "integer", nullable: true),
                    ItemPrototypeId = table.Column<int>(type: "integer", nullable: true),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    Heal = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    ProgramName = table.Column<string>(type: "text", nullable: true),
                    PossibleTargets = table.Column<int[]>(type: "integer[]", nullable: true),
                    Tick = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifierPrototypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifierPrototypes_AbilityPrototypes_AbilityPrototypeId",
                        column: x => x.AbilityPrototypeId,
                        principalTable: "AbilityPrototypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModifierPrototypes_CreaturePrototypes_CreaturePrototypeId",
                        column: x => x.CreaturePrototypeId,
                        principalTable: "CreaturePrototypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModifierPrototypes_ItemPrototypes_ItemPrototypeId",
                        column: x => x.ItemPrototypeId,
                        principalTable: "ItemPrototypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityPrototypes_CreaturePrototypeId",
                table: "AbilityPrototypes",
                column: "CreaturePrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreaturePrototypes_AttributesId",
                table: "CreaturePrototypes",
                column: "AttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrototypes_AttributesId",
                table: "ItemPrototypes",
                column: "AttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrototypes_CreaturePrototypeId",
                table: "ItemPrototypes",
                column: "CreaturePrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_CreaturePrototypeId",
                table: "ItemType",
                column: "CreaturePrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierPrototypes_AbilityPrototypeId",
                table: "ModifierPrototypes",
                column: "AbilityPrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierPrototypes_CreaturePrototypeId",
                table: "ModifierPrototypes",
                column: "CreaturePrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierPrototypes_ItemPrototypeId",
                table: "ModifierPrototypes",
                column: "ItemPrototypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "ModifierPrototypes");

            migrationBuilder.DropTable(
                name: "AbilityPrototypes");

            migrationBuilder.DropTable(
                name: "ItemPrototypes");

            migrationBuilder.DropTable(
                name: "CreaturePrototypes");

            migrationBuilder.DropTable(
                name: "Attributes");
        }
    }
}
