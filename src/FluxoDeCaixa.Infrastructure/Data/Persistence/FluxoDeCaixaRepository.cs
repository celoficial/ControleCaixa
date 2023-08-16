using FluxoDeCaixa.Application.Common.Interfaces;
using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FluxoDeCaixa.Infrastructure.Data.Persistence
{
    public class FluxoDeCaixaRepository : IFluxoDeCaixaRepository
    {
        private readonly IFluxoDeCaixaDbContext _dbContext;
        private static readonly object _lockObject = new object();

        public FluxoDeCaixaRepository(IFluxoDeCaixaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Aggregate_Root.FluxoDeCaixa?> ObterFluxoDeCaixaPorData(DateTime data)
        {
            return await _dbContext.FluxosDeCaixa
                .Include(p => p.Transacoes)
                .FirstOrDefaultAsync(f => f.Data.Date == data.Date);
        }
        public async Task<List<Domain.Aggregate_Root.FluxoDeCaixa>> ObterTodosOsFluxosDeCaixaAsync()
        {
            return await _dbContext.FluxosDeCaixa.Include(p => p.Transacoes).AsNoTracking().ToListAsync();
        }
        public decimal CalcularConsolidadoTotal()
        {
            lock (_lockObject)
            {
                var consolidadoTotal = _dbContext.FluxosDeCaixa
                    .SelectMany(f => f.Transacoes)
                    .AsNoTracking()
                    .Sum(t => t.isCredito ? t.Valor : -t.Valor);

                return consolidadoTotal;
            }
        }

        public async Task AdicionarFluxoDeCaixaAsync(Domain.Aggregate_Root.FluxoDeCaixa fluxoDeCaixa)
        {
            await _dbContext.FluxosDeCaixa.AddAsync(fluxoDeCaixa);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateFluxoDeCaixa(Domain.Aggregate_Root.FluxoDeCaixa fluxoDeCaixa)
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                if (entry.Entity is Transacao && entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Added;
                }
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

    }
}
