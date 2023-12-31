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
    [Migration("20231007174530_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
#pragma warning restore 612, 618
        }
    }
}
