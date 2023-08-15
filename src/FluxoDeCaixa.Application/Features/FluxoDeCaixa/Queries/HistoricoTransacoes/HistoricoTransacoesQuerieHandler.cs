using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using MediatR;

namespace FluxoDeCaixa.Application.Features.FluxoDeCaixa.Queries.HistoricoTransacoes
{
    public class HistoricoTransacoesQuerieHandler : IRequestHandler<HistoricoTransacoesQuerie, List<Domain.Aggregate_Root.FluxoDeCaixa>>
    {
        private readonly IFluxoDeCaixaRepository _fluxoDeCaixaRepository;

        public HistoricoTransacoesQuerieHandler(IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            _fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }

        public async Task<List<Domain.Aggregate_Root.FluxoDeCaixa>> Handle(HistoricoTransacoesQuerie request, CancellationToken cancellationToken)
        {
            var historico = await _fluxoDeCaixaRepository.ObterTodosOsFluxosDeCaixaAsync();
            return historico;
        }
    }
}
