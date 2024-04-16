using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore;

namespace ToxicLab.InfraEstrutura.Repositorio
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Dominio.Entidades.Cliente> Clientes { get; set; }
        public DbSet<Dominio.Entidades.Exame> Exames { get; set; }

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
