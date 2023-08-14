using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Domain.Aggregate_Root
{
    public class FluxoDeCaixa
    {
        public Guid Id { get; private set; }
        public DateOnly Data { get; private set; }

        public List<Transacao> Transacoes { get; private set; } = new List<Transacao>();

        private FluxoDeCaixa()
        {

        }

        public FluxoDeCaixa(List<Transacao> transacoes, DateOnly data)
        {
            Transacoes = transacoes;
            Data = data;
            Id = Guid.NewGuid();
        }

        public void AdicionarTransacao(decimal valor, bool isCredito)
        {
            var transacao = new Transacao(valor, isCredito);
            Transacoes.Add(transacao);
        }
    }
}
