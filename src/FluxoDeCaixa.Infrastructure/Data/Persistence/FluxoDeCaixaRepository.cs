using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FluxoDeCaixa.Infrastructure.Data.Persistence
{
    public class FluxoDeCaixaRepository : IFluxoDeCaixaRepository
    {
        private readonly IFluxoDeCaixaDbContext _dbContext;

        public FluxoDeCaixaRepository(IFluxoDeCaixaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Aggregate_Root.FluxoDeCaixa> ObterFluxoDeCaixaPorData(DateOnly data)
        {
            return await _dbContext.FluxosDeCaixa
                .FirstAsync(f => f.Data == data);
        }
        public async Task<List<Domain.Aggregate_Root.FluxoDeCaixa>> ObterTodosOsFluxosDeCaixaAsync()
        {
            return await _dbContext.FluxosDeCaixa.Include(p => p.Transacoes).ToListAsync();
        }
        public async Task<decimal> CalcularConsolidadoTotal()
        {
            var consolidadoTotal = await _dbContext.FluxosDeCaixa
                .SelectMany(f => f.Transacoes)
                .AsNoTracking()
                .SumAsync(t => t.isCredito ? t.Valor : -t.Valor);

            return consolidadoTotal;
        }

        public Task AdicionarFluxoDeCaixaAsync(Domain.Aggregate_Root.FluxoDeCaixa fluxoDeCaixa)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

    }
}
