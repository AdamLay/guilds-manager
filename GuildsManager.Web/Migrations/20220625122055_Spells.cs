using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GuildsManager.Web.Migrations
{
    public partial class Spells : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    School = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Rank = table.Column<byte>(type: "smallint", nullable: false),
                    Roll = table.Column<byte>(type: "smallint", nullable: true),
                    AoE = table.Column<bool>(type: "boolean", nullable: false),
                    Vs = table.Column<int>(type: "integer", nullable: true),
                    Range = table.Column<byte>(type: "smallint", nullable: true),
                    Self = table.Column<bool>(type: "boolean", nullable: false),
                    InVision = table.Column<bool>(type: "boolean", nullable: false),
                    Effect = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spells");
        }
    }
}
