using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDBAPI.Migrations
{
    public partial class TableArtiklarAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artiklars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produktnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produktbeskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pris = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    Tillverkare = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiklars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artiklars");
        }
    }
}
