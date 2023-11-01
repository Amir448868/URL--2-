using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL__2_.Migrations
{
    public partial class Primermigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasURL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCategoria = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasURL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    UrlCorta = table.Column<string>(type: "TEXT", nullable: true),
                    Visitas = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urls_CategoriasURL_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasURL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_CategoriaId",
                table: "Urls",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");

            migrationBuilder.DropTable(
                name: "CategoriasURL");
        }
    }
}
