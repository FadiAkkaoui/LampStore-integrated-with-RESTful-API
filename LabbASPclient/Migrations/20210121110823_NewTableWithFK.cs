using Microsoft.EntityFrameworkCore.Migrations;

namespace LabbASPclient.Migrations
{
    public partial class NewTableWithFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Artiklars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kategorinamn = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.KategoriId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artiklars_KategoriId",
                table: "Artiklars",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artiklars_Kategoris_KategoriId",
                table: "Artiklars",
                column: "KategoriId",
                principalTable: "Kategoris",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiklars_Kategoris_KategoriId",
                table: "Artiklars");

            migrationBuilder.DropTable(
                name: "Kategoris");

            migrationBuilder.DropIndex(
                name: "IX_Artiklars_KategoriId",
                table: "Artiklars");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Artiklars");
        }
    }
}
