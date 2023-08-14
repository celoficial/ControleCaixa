using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Infrastructure.Data.Persistence
{
    internal class TransacaoRepository : ITransacaoRepository
    {
        public Task AdicionarTransacaoAsync(Transacao transacao)
        {
            throw new NotImplementedException();
        }

        public Task<Transacao> ObterTransacaoAsync(Guid transacaoId)
        {
            throw new NotImplementedException();
        }
    }
}
