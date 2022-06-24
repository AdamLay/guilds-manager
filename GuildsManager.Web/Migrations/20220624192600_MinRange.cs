using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class MinRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MinRange",
                table: "Attacks",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinRange",
                table: "Attacks");
        }
    }
}
