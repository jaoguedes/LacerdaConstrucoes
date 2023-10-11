using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LacerdaContrucoes.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCadCompras",
                columns: table => new
                {
                    CadComprasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaDaCompra = table.Column<int>(type: "int", nullable: false),
                    DataDaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCadCompras", x => x.CadComprasId);
                    table.ForeignKey(
                        name: "FK_tbCadCompras_tbFornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tbFornecedores",
                        principalColumn: "FornecedorId");
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    CompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CadComprasId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    qtdCompra = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compra_tbCadCompras_CadComprasId",
                        column: x => x.CadComprasId,
                        principalTable: "tbCadCompras",
                        principalColumn: "CadComprasId");
                    table.ForeignKey(
                        name: "FK_Compra_tbProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tbProdutos",
                        principalColumn: "ProdutoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CadComprasId",
                table: "Compra",
                column: "CadComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ProdutoId",
                table: "Compra",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCadCompras_FornecedorId",
                table: "tbCadCompras",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "tbCadCompras");
        }
    }
}
