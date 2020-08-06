using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesOnline.Migrations
{
    public partial class AddCarrinhoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhosCompras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhosCompras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensCarrinhosCompras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLanche = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    IdCarrinhoCompra = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinhosCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCarrinhosCompras_CarrinhosCompras_IdCarrinhoCompra",
                        column: x => x.IdCarrinhoCompra,
                        principalTable: "CarrinhosCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCarrinhosCompras_Lanches_IdLanche",
                        column: x => x.IdLanche,
                        principalTable: "Lanches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinhosCompras_IdCarrinhoCompra",
                table: "ItensCarrinhosCompras",
                column: "IdCarrinhoCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinhosCompras_IdLanche",
                table: "ItensCarrinhosCompras",
                column: "IdLanche");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCarrinhosCompras");

            migrationBuilder.DropTable(
                name: "CarrinhosCompras");
        }
    }
}
