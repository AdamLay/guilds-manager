using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Force = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FactionId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Keywords = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Slots = table.Column<byte>(type: "smallint", nullable: false),
                    UnitNumber = table.Column<byte>(type: "smallint", nullable: false),
                    Might = table.Column<byte>(type: "smallint", nullable: false),
                    Healing = table.Column<bool>(type: "boolean", nullable: false),
                    Dex = table.Column<byte>(type: "smallint", nullable: false),
                    IgnoreDifficultTerrain = table.Column<bool>(type: "boolean", nullable: false),
                    Levitating = table.Column<bool>(type: "boolean", nullable: false),
                    Will = table.Column<byte>(type: "smallint", nullable: false),
                    Def = table.Column<byte>(type: "smallint", nullable: false),
                    Shield = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelCards_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<short>(type: "smallint", nullable: false),
                    CardId1 = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Text = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Passive = table.Column<bool>(type: "boolean", nullable: false),
                    Fatigue = table.Column<bool>(type: "boolean", nullable: false),
                    Torment = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_ModelCards_CardId1",
                        column: x => x.CardId1,
                        principalTable: "ModelCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<short>(type: "smallint", nullable: false),
                    CardId1 = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Attacks = table.Column<byte>(type: "smallint", nullable: false),
                    AoE = table.Column<bool>(type: "boolean", nullable: false),
                    Range = table.Column<byte>(type: "smallint", nullable: false),
                    Arc = table.Column<byte>(type: "smallint", nullable: false),
                    Element = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attacks_ModelCards_CardId1",
                        column: x => x.CardId1,
                        principalTable: "ModelCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResistancesWeaknesses",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<short>(type: "smallint", nullable: false),
                    CardId1 = table.Column<int>(type: "integer", nullable: false),
                    Element = table.Column<int>(type: "integer", nullable: false),
                    Effect = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResistancesWeaknesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResistancesWeaknesses_ModelCards_CardId1",
                        column: x => x.CardId1,
                        principalTable: "ModelCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CardId1",
                table: "Abilities",
                column: "CardId1");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_CardId1",
                table: "Attacks",
                column: "CardId1");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCards_FactionId",
                table: "ModelCards",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResistancesWeaknesses_CardId1",
                table: "ResistancesWeaknesses",
                column: "CardId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "ResistancesWeaknesses");

            migrationBuilder.DropTable(
                name: "ModelCards");

            migrationBuilder.DropTable(
                name: "Factions");
        }
    }
}
