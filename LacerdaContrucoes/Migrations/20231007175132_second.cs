using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LacerdaContrucoes.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    qnt = table.Column<int>(type: "int", nullable: false),
                    PrecoUni = table.Column<int>(type: "int", nullable: false),
                    CategoriaDeProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProdutos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_tbProdutos_tbCategoriaDeProdutos_CategoriaDeProdutosId",
                        column: x => x.CategoriaDeProdutosId,
                        principalTable: "tbCategoriaDeProdutos",
                        principalColumn: "CategoriaDeProdutosId");
                    table.ForeignKey(
                        name: "FK_tbProdutos_tbFornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tbFornecedores",
                        principalColumn: "FornecedorId");
                });

            migrationBuilder.CreateTable(
                name: "tbVendas",
                columns: table => new
                {
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    qtdVendas = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVendas", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_tbVendas_tbProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tbProdutos",
                        principalColumn: "ProdutoId");
                });

            migrationBuilder.CreateTable(
                name: "tbCadVendas",
                columns: table => new
                {
                    CadVendasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaDaVenda = table.Column<int>(type: "int", nullable: false),
                    DataDaVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCadVendas", x => x.CadVendasId);
                    table.ForeignKey(
                        name: "FK_tbCadVendas_tbVendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "tbVendas",
                        principalColumn: "VendaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbCadVendas_VendaId",
                table: "tbCadVendas",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_CategoriaDeProdutosId",
                table: "tbProdutos",
                column: "CategoriaDeProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_FornecedorId",
                table: "tbProdutos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVendas_ProdutoId",
                table: "tbVendas",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCadVendas");

            migrationBuilder.DropTable(
                name: "tbVendas");

            migrationBuilder.DropTable(
                name: "tbProdutos");
        }
    }
}
