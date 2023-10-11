using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LacerdaContrucoes.Migrations
{
    /// <inheritdoc />
    public partial class Tree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCadVendas_tbVendas_VendaId",
                table: "tbCadVendas");

            migrationBuilder.RenameColumn(
                name: "VendaId",
                table: "tbCadVendas",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_tbCadVendas_VendaId",
                table: "tbCadVendas",
                newName: "IX_tbCadVendas_ClienteId");

            migrationBuilder.AddColumn<Guid>(
                name: "CadVendasId",
                table: "tbVendas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NotaDaVenda",
                table: "tbCadVendas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_tbVendas_CadVendasId",
                table: "tbVendas",
                column: "CadVendasId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCadVendas_tbClientes_ClienteId",
                table: "tbCadVendas",
                column: "ClienteId",
                principalTable: "tbClientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbVendas_tbCadVendas_CadVendasId",
                table: "tbVendas",
                column: "CadVendasId",
                principalTable: "tbCadVendas",
                principalColumn: "CadVendasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCadVendas_tbClientes_ClienteId",
                table: "tbCadVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_tbVendas_tbCadVendas_CadVendasId",
                table: "tbVendas");

            migrationBuilder.DropIndex(
                name: "IX_tbVendas_CadVendasId",
                table: "tbVendas");

            migrationBuilder.DropColumn(
                name: "CadVendasId",
                table: "tbVendas");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "tbCadVendas",
                newName: "VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_tbCadVendas_ClienteId",
                table: "tbCadVendas",
                newName: "IX_tbCadVendas_VendaId");

            migrationBuilder.AlterColumn<Guid>(
                name: "NotaDaVenda",
                table: "tbCadVendas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCadVendas_tbVendas_VendaId",
                table: "tbCadVendas",
                column: "VendaId",
                principalTable: "tbVendas",
                principalColumn: "VendaId");
        }
    }
}
