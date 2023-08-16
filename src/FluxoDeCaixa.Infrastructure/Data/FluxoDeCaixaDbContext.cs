using FluxoDeCaixa.Application.Common.Interfaces;
using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FluxoDeCaixa.Infrastructure.Data
{
    public class FluxoDeCaixaDbContext : DbContext, IFluxoDeCaixaDbContext
    {

        public DbSet<FluxoDeCaixa.Domain.Aggregate_Root.FluxoDeCaixa> FluxosDeCaixa { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public ChangeTracker DbContextChangeTracker => ChangeTracker;

        public FluxoDeCaixaDbContext(DbContextOptions<FluxoDeCaixaDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FluxoDeCaixaDbContext).Assembly);
        }
    }
}
