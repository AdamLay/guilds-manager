using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class HeroicWounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "HeroicWounds",
                table: "ModelCards",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroicWounds",
                table: "ModelCards");
        }
    }
}
