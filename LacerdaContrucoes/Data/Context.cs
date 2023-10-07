using LacerdaContrucoes.Models;
using Microsoft.EntityFrameworkCore;

namespace LacerdaContrucoes.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Fornecedor> Fornecedores { get; set;} 
        public DbSet<CategoriaDeProdutos> CategoriaDeProdutos { get; set;}
        public DbSet<Produto> Produtos { get; set;}
        public DbSet<Venda> Venda { get; set;}
        public DbSet<CadVendas> CadVendas { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("tbClientes");
            modelBuilder.Entity<Fornecedor>().ToTable("tbFornecedores");
            modelBuilder.Entity<CategoriaDeProdutos>().ToTable("tbCategoriaDeProdutos");
            modelBuilder.Entity<Produto>().ToTable("tbProdutos");
            modelBuilder.Entity<Venda>().ToTable("tbVendas");
            modelBuilder.Entity<CadVendas>().ToTable("tbCadVendas");
        }

    }
}
