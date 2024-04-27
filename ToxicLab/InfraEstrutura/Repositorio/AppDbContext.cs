using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore;
using ToxicLab.Dominio.Entidades;

namespace ToxicLab.InfraEstrutura.Repositorio
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Exame> exames { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dominio.Entidades.Cliente>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Dominio.Entidades.Cliente>()
                .Property(x => x.Nome).HasMaxLength(100);
            modelBuilder.Entity<Dominio.Entidades.Cliente>()
                .Property(x => x.Cpf).HasColumnType("char(11)");


        }
    }
}
