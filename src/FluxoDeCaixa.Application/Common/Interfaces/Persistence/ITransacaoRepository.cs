using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Application.Common.Interfaces.Persistence
{
    public interface ITransacaoRepository
    {
        Task<Transacao> ObterTransacaoAsync(Guid transacaoId);
        Task AdicionarTransacaoAsync(Transacao transacao);
    }
}
