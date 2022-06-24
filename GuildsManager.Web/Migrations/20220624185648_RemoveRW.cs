using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class RemoveRW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResistancesWeaknesses");

            migrationBuilder.AddColumn<string>(
                name: "RW",
                table: "ModelCards",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RW",
                table: "ModelCards");

            migrationBuilder.CreateTable(
                name: "ResistancesWeaknesses",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<short>(type: "smallint", nullable: false),
                    Effect = table.Column<int>(type: "integer", nullable: false),
                    Element = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResistancesWeaknesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResistancesWeaknesses_ModelCards_CardId",
                        column: x => x.CardId,
                        principalTable: "ModelCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResistancesWeaknesses_CardId",
                table: "ResistancesWeaknesses",
                column: "CardId");
        }
    }
}
