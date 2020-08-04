using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesOnline.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasLanches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasLanches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lanches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoCurta = table.Column<string>(maxLength: 100, nullable: true),
                    DescricaoDetalhada = table.Column<string>(maxLength: 255, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UrlImagem = table.Column<string>(maxLength: 200, nullable: true),
                    UrlImagemThumbnail = table.Column<string>(maxLength: 200, nullable: true),
                    EhLanchePreferido = table.Column<bool>(nullable: false),
                    PossuiEstoque = table.Column<bool>(nullable: false),
                    IdCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lanches_CategoriasLanches_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriasLanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lanches_IdCategoria",
                table: "Lanches",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lanches");

            migrationBuilder.DropTable(
                name: "CategoriasLanches");
        }
    }
}
