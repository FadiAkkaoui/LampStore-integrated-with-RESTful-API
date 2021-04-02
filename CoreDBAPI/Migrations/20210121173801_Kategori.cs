using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDBAPI.Migrations
{
    public partial class Kategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Artiklars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategorinamn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artiklars_KategoriId",
                table: "Artiklars",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artiklars_Kategori_KategoriId",
                table: "Artiklars",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiklars_Kategori_KategoriId",
                table: "Artiklars");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropIndex(
                name: "IX_Artiklars_KategoriId",
                table: "Artiklars");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Artiklars");
        }
    }
}
