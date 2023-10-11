using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LacerdaContrucoes.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategoriaDeProdutos",
                columns: table => new
                {
                    CategoriaDeProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDaCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoriaDeProdutos", x => x.CategoriaDeProdutosId);
                });

            migrationBuilder.CreateTable(
                name: "tbClientes",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteTelefone = table.Column<int>(type: "int", nullable: false),
                    ClienteCpf = table.Column<int>(type: "int", nullable: false),
                    ClienteEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteDataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbClientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "tbFornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FornecedorCNPJ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFornecedores", x => x.FornecedorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCategoriaDeProdutos");

            migrationBuilder.DropTable(
                name: "tbClientes");

            migrationBuilder.DropTable(
                name: "tbFornecedores");
        }
    }
}
