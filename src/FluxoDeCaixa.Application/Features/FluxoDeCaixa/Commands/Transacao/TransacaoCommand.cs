using ErrorOr;
using MediatR;

namespace FluxoDeCaixa.Application.Features.FluxoDeCaixa.Commands.Transacao
{
    public record TransacaoCommand(decimal valor, bool isCredito) : IRequest<ErrorOr<bool>>;
}
