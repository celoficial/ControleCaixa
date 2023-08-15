using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FluxoDeCaixa.Application.Common.Interfaces
{
    public interface IFluxoDeCaixaDbContext
    {
        public ChangeTracker ChangeTracker2 { get; }
        public DbSet<FluxoDeCaixa.Domain.Aggregate_Root.FluxoDeCaixa> FluxosDeCaixa { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
