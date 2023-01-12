﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pagamentos.Infrastructure.Persistence;

namespace Pagamentos.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PagamentosDbContext))]
    partial class PagamentosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pagamentos.Core.Entities.Prestadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Favorecido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Prestadores");
                });

            modelBuilder.Entity("Pagamentos.Core.Entities.Servicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPrestador")
                        .HasColumnType("int");

                    b.Property<string>("Servico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuariosId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdPrestador");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Pagamentos.Core.Entities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Pagamentos.Core.Entities.Prestadores", b =>
                {
                    b.HasOne("Pagamentos.Core.Entities.Usuarios", null)
                        .WithMany("Prestadores")
                        .HasForeignKey("UsuariosId");
                });

            modelBuilder.Entity("Pagamentos.Core.Entities.Servicos", b =>
                {
                    b.HasOne("Pagamentos.Core.Entities.Prestadores", "Prestadores")
                        .WithMany("Servicos")
                        .HasForeignKey("IdPrestador")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pagamentos.Core.Entities.Usuarios", null)
                        .WithMany("Servicos")
                        .HasForeignKey("UsuariosId");

                    b.Navigation("Prestadores");
                });

            modelBuilder.Entity("Pagamentos.Core.Entities.Prestadores", b =>
                {
                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Pagamentos.Core.Entities.Usuarios", b =>
                {
                    b.Navigation("Prestadores");

                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
