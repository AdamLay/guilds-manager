using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class IntToShort2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_ModelCards_CardId1",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_CardId1",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "CardId1",
                table: "Abilities");

            migrationBuilder.AlterColumn<short>(
                name: "CardId",
                table: "Abilities",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CardId",
                table: "Abilities",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_ModelCards_CardId",
                table: "Abilities",
                column: "CardId",
                principalTable: "ModelCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_ModelCards_CardId",
                table: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_CardId",
                table: "Abilities");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Abilities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<short>(
                name: "CardId1",
                table: "Abilities",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_CardId1",
                table: "Abilities",
                column: "CardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_ModelCards_CardId1",
                table: "Abilities",
                column: "CardId1",
                principalTable: "ModelCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
