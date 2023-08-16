using ErrorOr;
using FluxoDeCaixa.Application.Common.Interfaces;
using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using FluxoDeCaixa.Domain.Common.Errors;
using MediatR;
using Prometheus;

namespace FluxoDeCaixa.Application.Features.FluxoDeCaixa.Commands.Transacao
{
    public class TransacaoCommandHandler : IRequestHandler<TransacaoCommand, ErrorOr<bool>>
    {
        private readonly IFluxoDeCaixaRepository _fluxoDeCaixaRepository;
        private readonly IFluxoDeCaixaDbContext _dbContext;
        private readonly Counter _transacoesCounter;

        public TransacaoCommandHandler(IFluxoDeCaixaRepository fluxoDeCaixaRepository, IFluxoDeCaixaDbContext dbContext)
        {
            _fluxoDeCaixaRepository = fluxoDeCaixaRepository;
            _dbContext = dbContext;
            _transacoesCounter = Metrics.CreateCounter("transacoes_totais", "Total de transações realizadas", new CounterConfiguration
            {
                LabelNames = new[] { "tipo", "valor", "data" }
            });
        }

        public async Task<ErrorOr<bool>> Handle(TransacaoCommand request, CancellationToken cancellationToken)
        {
            if (request.valor < 0)
            {
                return Errors.Transacao.InvalidValue;
            }

            var fluxoCaixa = await _fluxoDeCaixaRepository.ObterFluxoDeCaixaPorData(DateTime.Now);

            if (fluxoCaixa is null)
            {
                var novoFC = new Domain.Aggregate_Root.FluxoDeCaixa(new List<Domain.Entities.Transacao>(), DateTime.Now);
                await _fluxoDeCaixaRepository.AdicionarFluxoDeCaixaAsync(novoFC);
                novoFC.AdicionarTransacao(request.valor, request.isCredito);

            }
            else
            {
                fluxoCaixa.AdicionarTransacao(request.valor, request.isCredito);
                _fluxoDeCaixaRepository.UpdateFluxoDeCaixa(fluxoCaixa);
            }


            await _fluxoDeCaixaRepository.SaveChangesAsync();
            _transacoesCounter.WithLabels(request.isCredito ? "credito" : "debito", request.valor.ToString(), DateTime.UtcNow.ToString()).Inc();
            return true;
        }
    }
}
