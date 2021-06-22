﻿// <auto-generated />
using System;
using ERP.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SalesForce.Data.Migrations
{
    [DbContext(typeof(SalesForceDbContext))]
    partial class SalesForceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.PedidoSequencia", "'PedidoSequencia', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ERP.Business.Models.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodigoIbge")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("ERP.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("CidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CnpjCpfDi")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("ConsumidorFinal")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("InscricaoEstadual")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoInscricaoEstadual")
                        .HasColumnType("int");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ERP.Business.Models.CondicaoPagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CondicoesPagamento");
                });

            modelBuilder.Entity("ERP.Business.Models.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("CidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CnpjCpfDi")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Crt")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("Fantasia")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("InscricaoEstadual")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(60);

                    b.Property<bool>("Padrao")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoInscricaoEstadual")
                        .HasColumnType("int");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ERP.Business.Models.FormaPagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("ConfiguracaoFiscal")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Credito")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("PermitirTroco")
                        .HasColumnType("bit");

                    b.Property<bool>("Tef")
                        .HasColumnType("bit");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("FormasPagamento");
                });

            modelBuilder.Entity("ERP.Business.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR PedidoSequencia");

                    b.Property<Guid>("CondicaoPagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FormaPagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondicaoPagamentoId");

                    b.HasIndex("FormaPagamentoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ERP.Business.Models.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Item")
                        .HasColumnType("int");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.Property<double>("ValorAcrescimo")
                        .HasColumnType("float");

                    b.Property<double>("ValorDesconto")
                        .HasColumnType("float");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidosItens");
                });

            modelBuilder.Entity("ERP.Business.Models.ProdutoServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoInterno")
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Estoque")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("PermiteFracionar")
                        .HasColumnType("bit");

                    b.Property<Guid>("UnidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeId");

                    b.ToTable("ProdutosServicos");
                });

            modelBuilder.Entity("ERP.Business.Models.Unidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("ERP.Business.Models.Cliente", b =>
                {
                    b.HasOne("ERP.Business.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ERP.Business.Models.Empresa", b =>
                {
                    b.HasOne("ERP.Business.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ERP.Business.Models.Pedido", b =>
                {
                    b.HasOne("ERP.Business.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ERP.Business.Models.CondicaoPagamento", "CondicaoPagamento")
                        .WithMany()
                        .HasForeignKey("CondicaoPagamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ERP.Business.Models.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ERP.Business.Models.PedidoItem", b =>
                {
                    b.HasOne("ERP.Business.Models.Pedido", "Pedido")
                        .WithMany("PedidoItens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP.Business.Models.ProdutoServico", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ERP.Business.Models.ProdutoServico", b =>
                {
                    b.HasOne("ERP.Business.Models.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
