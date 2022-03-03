using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Húsüzem.Data.Migrations
{
    public partial class husadatbazis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Husika",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terméknév = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ár = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alapanyag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GyártásIdeje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Husika", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Husika");
        }
    }
}
