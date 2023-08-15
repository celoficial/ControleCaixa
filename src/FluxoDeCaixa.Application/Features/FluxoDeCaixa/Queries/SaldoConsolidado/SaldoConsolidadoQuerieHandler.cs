using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using MediatR;

namespace FluxoDeCaixa.Application.Features.FluxoDeCaixa.Queries.SaldoConsolidado
{
    public class SaldoConsolidadoQuerieHandler : IRequestHandler<SaldoConsolidadoQuerie, decimal>
    {
        private readonly IFluxoDeCaixaRepository _fluxoDeCaixaRepository;
        private static readonly object _lockObject = new object(); // Objeto para travamento

        public SaldoConsolidadoQuerieHandler(IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            _fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }
        public Task<decimal> Handle(SaldoConsolidadoQuerie request, CancellationToken cancellationToken)
        {
            lock (_lockObject)
            {
                using var transaction = _fluxoDeCaixaRepository.BeginTransaction();

                try
                {
                    var saldoConsolidado = _fluxoDeCaixaRepository.CalcularConsolidadoTotal();
                    transaction.Commit();
                    return Task.FromResult(saldoConsolidado);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
