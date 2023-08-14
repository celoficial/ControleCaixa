namespace FluxoDeCaixa.Domain.Entities
{
    public class Transacao
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public bool isCredito { get; private set; }

        public Guid FluxoDeCaixaId { get; private set; }
        public FluxoDeCaixa.Domain.Aggregate_Root.FluxoDeCaixa FluxoDeCaixa { get; private set; } = null!;

        private Transacao()
        {

        }

        public Transacao(decimal valor, bool isCredito)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Data = DateTime.Now;
            this.isCredito = isCredito;
        }
    }
}
