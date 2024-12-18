﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore;
using ToxicLabMVC.Dominio.Entidades;
using ToxicLabMVC.Dominio.ObjetosDeValor;

namespace ToxicLabMVC.InfraEstrutura.Repositorio
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Exame> exames { get; set; }
        //public DbSet<TabelaDePrecos> tabela_precos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dominio.Entidades.Cliente>()
                .Property(x => x.ClienteId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Dominio.Entidades.Cliente>()
                .Property(x => x.Nome).HasMaxLength(100);
            modelBuilder.Entity<Dominio.Entidades.Cliente>()
                .Property(x => x.Cpf).HasColumnType("char(11)");
            
            

            //modelBuilder.Entity<TabelaDePrecos>()
            //    .HasNoKey();
            //modelBuilder.Entity<TabelaDePrecos>()
            //    .Property(x => x.ValorExame).HasColumnType("decimal");
            //modelBuilder.Entity<TabelaDePrecos>()
            //    .Property(x => x.ValorAnalise).HasColumnType("decimal");
            //modelBuilder.Entity<TabelaDePrecos>()
            //    .Property(x => x.ValorRepasse).HasColumnType("decimal");
            //modelBuilder.Entity<TabelaDePrecos>()
            //    .Property(x => x.ValorVoucher).HasColumnType("decimal");

        }
    }
}
