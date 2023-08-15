using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Domain.Aggregate_Root
{
    public class FluxoDeCaixa
    {
        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }

        public List<Transacao> Transacoes { get; private set; } = new List<Transacao>();

        private FluxoDeCaixa()
        {

        }

        public FluxoDeCaixa(List<Transacao> transacoes, DateTime data)
        {
            Transacoes = transacoes;
            Data = data;
            Id = Guid.NewGuid();
        }

        public void AdicionarTransacao(decimal valor, bool isCredito)
        {
            Transacoes.Add(new Transacao(valor, isCredito, Id, this));
        }
    }
}
