﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToxicLab.InfraEstrutura.Repositorio;

#nullable disable

namespace ToxicLab.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240501180421_AdicionadoAtivoEmClientes")]
    partial class AdicionadoAtivoEmClientes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ToxicLab.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

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

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("rg");

                    b.Property<DateOnly>("VencimentoCnh")
                        .HasColumnType("date")
                        .HasColumnName("vencimento_cnh");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("whatsapp");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("ToxicLab.Dominio.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

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
                        .IsRequired()
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

                    b.Property<int>("TiposLogradouro")
                        .HasColumnType("int")
                        .HasColumnName("tipo_logradouro");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("ToxicLab.Dominio.Entidades.Exame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ativo");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<DateOnly>("DataRealizado")
                        .HasColumnType("date")
                        .HasColumnName("data_realizado");

                    b.Property<DateOnly>("DataVencimento")
                        .HasColumnType("date")
                        .HasColumnName("data_vencimento");

                    b.Property<int>("MotivoExame")
                        .HasColumnType("int")
                        .HasColumnName("motivo_exame");

                    b.HasKey("Id");

                    b.ToTable("exames");
                });

            modelBuilder.Entity("ToxicLab.Dominio.Entidades.Endereco", b =>
                {
                    b.HasOne("ToxicLab.Dominio.Entidades.Cliente", null)
                        .WithOne("Endereco")
                        .HasForeignKey("ToxicLab.Dominio.Entidades.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToxicLab.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
