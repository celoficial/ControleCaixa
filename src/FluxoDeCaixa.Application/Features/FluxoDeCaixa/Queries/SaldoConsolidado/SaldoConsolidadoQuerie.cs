using MediatR;

namespace FluxoDeCaixa.Application.Features.FluxoDeCaixa.Queries.SaldoConsolidado
{
#pragma warning disable S2094 // Classes should not be empty
    public record SaldoConsolidadoQuerie() : IRequest<decimal>;
#pragma warning restore S2094 // Classes should not be empty
}
