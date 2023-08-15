using ErrorOr;

namespace FluxoDeCaixa.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Transacao
        {
            public static Error InvalidValue => Error.Validation(
                code: "Transacao.InvalidValue",
                description: "O Valor tem que ser maior que 0");
        }
    }
}
