using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class Abilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResistanceWeaknessJson",
                table: "ModelCards");

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<short>(type: "smallint", nullable: false),
                    CardId1 = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Passive = table.Column<bool>(type: "bit", nullable: false),
                    Fatigue = table.Column<bool>(type: "bit", nullable: false),
                    Torment = table.Column<bool>(type: "bit", nullable: false)
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
                name: "ResistancesWeaknesses",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<short>(type: "smallint", nullable: false),
                    CardId1 = table.Column<int>(type: "int", nullable: false),
                    Element = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_ResistancesWeaknesses_CardId1",
                table: "ResistancesWeaknesses",
                column: "CardId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "ResistancesWeaknesses");

            migrationBuilder.AddColumn<string>(
                name: "ResistanceWeaknessJson",
                table: "ModelCards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
