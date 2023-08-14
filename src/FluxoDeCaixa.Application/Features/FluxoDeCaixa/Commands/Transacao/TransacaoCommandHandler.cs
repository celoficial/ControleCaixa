using ErrorOr;
using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using FluxoDeCaixa.Domain.Common.Errors;
using MediatR;

namespace FluxoDeCaixa.Application.Features.FluxoDeCaixa.Commands.Transacao
{
    internal class TransacaoCommandHandler : IRequestHandler<TransacaoCommand, ErrorOr<bool>>
    {
        private readonly IFluxoDeCaixaRepository _fluxoDeCaixaRepository;

        public TransacaoCommandHandler(IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            _fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }

        public async Task<ErrorOr<bool>> Handle(TransacaoCommand request, CancellationToken cancellationToken)
        {
            if (request.valor < 0)
            {
                return Errors.Transacao.InvalidValue;
            }

            var fluxoCaixa = await _fluxoDeCaixaRepository.ObterFluxoDeCaixaPorData(DateOnly.FromDateTime(DateTime.Now));
            if (fluxoCaixa is null)
            {
                var novoFC = new Domain.Aggregate_Root.FluxoDeCaixa(new List<Domain.Entities.Transacao>(), DateOnly.FromDateTime(DateTime.Now));
                await _fluxoDeCaixaRepository.AdicionarFluxoDeCaixaAsync(novoFC);
                novoFC.AdicionarTransacao(request.valor, request.isCredito);
                return true;

            }

            fluxoCaixa.AdicionarTransacao(request.valor, request.isCredito);
            return true;
        }
    }
}
