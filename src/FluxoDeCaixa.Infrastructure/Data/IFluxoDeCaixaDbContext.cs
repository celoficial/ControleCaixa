using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FluxoDeCaixa.Infrastructure.Data
{
    public interface IFluxoDeCaixaDbContext
    {
        public DbSet<FluxoDeCaixa.Domain.Aggregate_Root.FluxoDeCaixa> FluxosDeCaixa { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
