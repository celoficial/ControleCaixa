using FluxoDeCaixa.Application.Common.Interfaces;
using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluxoDeCaixa.Infrastructure.Data.Persistence
{
    internal class TransacaoRepository : ITransacaoRepository
    {
        private readonly IFluxoDeCaixaDbContext _dbContext;

        public TransacaoRepository(IFluxoDeCaixaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AdicionarTransacaoAsync(Transacao transacao)
        {
            await _dbContext.Transacoes.AddAsync(transacao);
        }

        public async Task<Transacao?> ObterTransacaoAsync(Guid transacaoId)
        {
            return await _dbContext.Transacoes.FirstOrDefaultAsync(t => t.Id == transacaoId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
