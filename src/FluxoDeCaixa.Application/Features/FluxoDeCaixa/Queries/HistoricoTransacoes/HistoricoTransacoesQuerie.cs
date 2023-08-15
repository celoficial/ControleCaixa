using MediatR;

namespace FluxoDeCaixa.Application.Features.FluxoDeCaixa.Queries.HistoricoTransacoes
{
#pragma warning disable S2094 // Classes should not be empty
    public record HistoricoTransacoesQuerie() : IRequest<List<Domain.Aggregate_Root.FluxoDeCaixa>>;
#pragma warning restore S2094 // Classes should not be empty
}
