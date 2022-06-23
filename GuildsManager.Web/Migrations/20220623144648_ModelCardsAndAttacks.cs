using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class ModelCardsAndAttacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactionId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Slots = table.Column<byte>(type: "tinyint", nullable: false),
                    UnitNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    Might = table.Column<byte>(type: "tinyint", nullable: false),
                    Healing = table.Column<bool>(type: "bit", nullable: false),
                    Dex = table.Column<byte>(type: "tinyint", nullable: false),
                    IgnoreDifficultTerrain = table.Column<bool>(type: "bit", nullable: false),
                    Levitating = table.Column<bool>(type: "bit", nullable: false),
                    Will = table.Column<byte>(type: "tinyint", nullable: false),
                    Def = table.Column<byte>(type: "tinyint", nullable: false),
                    Shield = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Attacks",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<short>(type: "smallint", nullable: false),
                    CardId1 = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Attacks = table.Column<byte>(type: "tinyint", nullable: false),
                    AoE = table.Column<bool>(type: "bit", nullable: false),
                    Range = table.Column<byte>(type: "tinyint", nullable: false),
                    Arc = table.Column<byte>(type: "tinyint", nullable: false),
                    Element = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_CardId1",
                table: "Attacks",
                column: "CardId1");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCards_FactionId",
                table: "ModelCards",
                column: "FactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "ModelCards");
        }
    }
}
