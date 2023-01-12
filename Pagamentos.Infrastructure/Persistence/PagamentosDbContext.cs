using Microsoft.EntityFrameworkCore;
using Pagamentos.Core.Entities;
using System.Reflection;

namespace Pagamentos.Infrastructure.Persistence
{
    public class PagamentosDbContext : DbContext
    {
        public PagamentosDbContext(DbContextOptions<PagamentosDbContext> options) : base(options)
        {

        }

        public DbSet<Prestadores> Prestadores { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
