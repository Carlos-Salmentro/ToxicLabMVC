﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToxicLabMVC.InfraEstrutura.Repositorio;

#nullable disable

namespace ToxiLabMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ToxicLabMVC.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ativo");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cnh");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("char(11)")
                        .HasColumnName("cpf");

                    b.Property<DateOnly>("DataNotificacao")
                        .HasColumnType("date")
                        .HasColumnName("data_notificacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<DateOnly>("Nascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("NumeroCustodia")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("numero_custodia");

                    b.Property<DateOnly>("VencimentoCnh")
                        .HasColumnType("date")
                        .HasColumnName("vencimento_cnh");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("whatsapp");

                    b.HasKey("ClienteId");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("ToxicLabMVC.Dominio.Entidades.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cep");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext")
                        .HasColumnName("complemento");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("logradouro");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("numero");

                    b.Property<int>("TipoLogradouro")
                        .HasColumnType("int")
                        .HasColumnName("tipo_logradouro");

                    b.HasKey("EnderecoId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("ToxicLabMVC.Dominio.Entidades.Exame", b =>
                {
                    b.Property<int>("ExameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ExameId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ativo");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("DataRealizado")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_realizado");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_vencimento");

                    b.Property<int>("MotivoExame")
                        .HasColumnType("int")
                        .HasColumnName("motivo_exame");

                    b.Property<decimal>("ValorAnalise")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("valor_analise");

                    b.Property<decimal>("ValorExame")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("valor_exame");

                    b.Property<decimal>("ValorRepasse")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("valor_repasse");

                    b.Property<bool>("Voucher")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("voucher");

                    b.HasKey("ExameId");

                    b.HasIndex("ClienteId");

                    b.ToTable("exames");
                });

            modelBuilder.Entity("ToxicLabMVC.Dominio.Entidades.Endereco", b =>
                {
                    b.HasOne("ToxicLabMVC.Dominio.Entidades.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("ToxicLabMVC.Dominio.Entidades.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ToxicLabMVC.Dominio.Entidades.Exame", b =>
                {
                    b.HasOne("ToxicLabMVC.Dominio.Entidades.Cliente", null)
                        .WithMany("Exames")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToxicLabMVC.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Exames");
                });
#pragma warning restore 612, 618
        }
    }
}
