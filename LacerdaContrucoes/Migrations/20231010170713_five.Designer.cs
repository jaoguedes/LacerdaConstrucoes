﻿// <auto-generated />
using System;
using LacerdaContrucoes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LacerdaContrucoes.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231010170713_five")]
    partial class five
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LacerdaContrucoes.Models.CadCompras", b =>
                {
                    b.Property<Guid>("CadComprasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDaCompra")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NotaDaCompra")
                        .HasColumnType("int");

                    b.HasKey("CadComprasId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("tbCadCompras", (string)null);
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.CadVendas", b =>
                {
                    b.Property<Guid>("CadVendasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDaVenda")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaDaVenda")
                        .HasColumnType("int");

                    b.HasKey("CadVendasId");

                    b.HasIndex("ClienteId");

                    b.ToTable("tbCadVendas", (string)null);
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.CategoriaDeProdutos", b =>
                {
                    b.Property<Guid>("CategoriaDeProdutosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeDaCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaDeProdutosId");

                    b.ToTable("tbCategoriaDeProdutos", (string)null);
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClienteCpf")
                        .HasColumnType("int");

                    b.Property<DateTime>("ClienteDataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClienteEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClienteNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteTelefone")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.ToTable("tbClientes", (string)null);
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Compra", b =>
                {
                    b.Property<Guid>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CadComprasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("qtdCompra")
                        .HasColumnType("int");

                    b.HasKey("CompraId");

                    b.HasIndex("CadComprasId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FornecedorCNPJ")
                        .HasColumnType("int");

                    b.Property<string>("FornecedorNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FornecedorId");

                    b.ToTable("tbFornecedores", (string)null);
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Produto", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaDeProdutosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PrecoUni")
                        .HasColumnType("int");

                    b.Property<int>("qnt")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaDeProdutosId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("tbProdutos", (string)null);
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Venda", b =>
                {
                    b.Property<Guid>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CadVendasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("qtdVendas")
                        .HasColumnType("int");

                    b.HasKey("VendaId");

                    b.HasIndex("CadVendasId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tbVendas", (string)null);
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.CadCompras", b =>
                {
                    b.HasOne("LacerdaContrucoes.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.CadVendas", b =>
                {
                    b.HasOne("LacerdaContrucoes.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Compra", b =>
                {
                    b.HasOne("LacerdaContrucoes.Models.CadCompras", "CadCompras")
                        .WithMany("Compras")
                        .HasForeignKey("CadComprasId");

                    b.HasOne("LacerdaContrucoes.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("CadCompras");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Produto", b =>
                {
                    b.HasOne("LacerdaContrucoes.Models.CategoriaDeProdutos", "CategoriaDeProdutos")
                        .WithMany()
                        .HasForeignKey("CategoriaDeProdutosId");

                    b.HasOne("LacerdaContrucoes.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.Navigation("CategoriaDeProdutos");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.Venda", b =>
                {
                    b.HasOne("LacerdaContrucoes.Models.CadVendas", "CadVendas")
                        .WithMany("Vendas")
                        .HasForeignKey("CadVendasId");

                    b.HasOne("LacerdaContrucoes.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("CadVendas");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.CadCompras", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("LacerdaContrucoes.Models.CadVendas", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
