using Microsoft.EntityFrameworkCore.Migrations;

namespace LabbASPclient.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artiklars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Produktnamn = table.Column<string>(type: "TEXT", nullable: true),
                    Produktbeskrivning = table.Column<string>(type: "TEXT", nullable: true),
                    Tillverkare = table.Column<string>(type: "TEXT", nullable: true),
                    Pris = table.Column<int>(type: "INTEGER", nullable: false),
                    Antal = table.Column<int>(type: "INTEGER", nullable: false)
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
