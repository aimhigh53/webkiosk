using Microsoft.EntityFrameworkCore.Migrations;

namespace cSharpPro.Migrations
{
    public partial class kiosk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bagdbs",
                columns: table => new
                {
                    NO = table.Column<string>(nullable: false),
                    Age = table.Column<string>(nullable: true),
                    picked = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bagdbs", x => x.NO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bagdbs");
        }
    }
}
