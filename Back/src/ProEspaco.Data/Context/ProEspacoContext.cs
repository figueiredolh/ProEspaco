using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProEspaco.Business.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProEspaco.Data.Context
{
    public class ProEspacoContext : DbContext
    {
        public ProEspacoContext(DbContextOptions<ProEspacoContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set;}
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ServicoSubtipo> ServicoSubtipo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplicar as alterações mapeadas por cada mapping no assembly, com ApplyConfigFromAssembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProEspacoContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
