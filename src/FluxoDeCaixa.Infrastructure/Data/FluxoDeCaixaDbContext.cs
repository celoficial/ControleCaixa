using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluxoDeCaixa.Infrastructure.Data
{
    internal class FluxoDeCaixaDbContext : DbContext, IFluxoDeCaixaDbContext
    {
        public DbSet<FluxoDeCaixa.Domain.Aggregate_Root.FluxoDeCaixa> FluxosDeCaixa { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        public FluxoDeCaixaDbContext(DbContextOptions<FluxoDeCaixaDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FluxoDeCaixaDbContext).Assembly);
        }
    }
}
