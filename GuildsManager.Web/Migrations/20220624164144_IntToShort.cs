using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class IntToShort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attacks_ModelCards_CardId1",
                table: "Attacks");

            migrationBuilder.DropForeignKey(
                name: "FK_ResistancesWeaknesses_ModelCards_CardId1",
                table: "ResistancesWeaknesses");

            migrationBuilder.DropIndex(
                name: "IX_ResistancesWeaknesses_CardId1",
                table: "ResistancesWeaknesses");

            migrationBuilder.DropIndex(
                name: "IX_Attacks_CardId1",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "CardId1",
                table: "ResistancesWeaknesses");

            migrationBuilder.DropColumn(
                name: "CardId1",
                table: "Attacks");

            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "ModelCards",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<short>(
                name: "CardId1",
                table: "Abilities",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Abilities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateIndex(
                name: "IX_ResistancesWeaknesses_CardId",
                table: "ResistancesWeaknesses",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_CardId",
                table: "Attacks",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attacks_ModelCards_CardId",
                table: "Attacks",
                column: "CardId",
                principalTable: "ModelCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResistancesWeaknesses_ModelCards_CardId",
                table: "ResistancesWeaknesses",
                column: "CardId",
                principalTable: "ModelCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attacks_ModelCards_CardId",
                table: "Attacks");

            migrationBuilder.DropForeignKey(
                name: "FK_ResistancesWeaknesses_ModelCards_CardId",
                table: "ResistancesWeaknesses");

            migrationBuilder.DropIndex(
                name: "IX_ResistancesWeaknesses_CardId",
                table: "ResistancesWeaknesses");

            migrationBuilder.DropIndex(
                name: "IX_Attacks_CardId",
                table: "Attacks");

            migrationBuilder.AddColumn<int>(
                name: "CardId1",
                table: "ResistancesWeaknesses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ModelCards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CardId1",
                table: "Attacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CardId1",
                table: "Abilities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "CardId",
                table: "Abilities",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_ResistancesWeaknesses_CardId1",
                table: "ResistancesWeaknesses",
                column: "CardId1");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_CardId1",
                table: "Attacks",
                column: "CardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attacks_ModelCards_CardId1",
                table: "Attacks",
                column: "CardId1",
                principalTable: "ModelCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResistancesWeaknesses_ModelCards_CardId1",
                table: "ResistancesWeaknesses",
                column: "CardId1",
                principalTable: "ModelCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
