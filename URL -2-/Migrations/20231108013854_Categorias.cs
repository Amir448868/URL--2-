using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL__2_.Migrations
{
    public partial class Categorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_CategoriasURL_CategoriaId",
                table: "Urls");

            migrationBuilder.DropTable(
                name: "CategoriasURL");

            migrationBuilder.DropIndex(
                name: "IX_Urls_CategoriaId",
                table: "Urls");

            migrationBuilder.AddColumn<int>(
                name: "Categorias",
                table: "Urls",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorias",
                table: "Urls");

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

            migrationBuilder.CreateIndex(
                name: "IX_Urls_CategoriaId",
                table: "Urls",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_CategoriasURL_CategoriaId",
                table: "Urls",
                column: "CategoriaId",
                principalTable: "CategoriasURL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
