using FluxoDeCaixa.Application.Features.FluxoDeCaixa.Commands.Transacao;
using FluxoDeCaixa.Application.Features.FluxoDeCaixa.Queries.HistoricoTransacoes;
using FluxoDeCaixa.Application.Features.FluxoDeCaixa.Queries.SaldoConsolidado;
using FluxoDeCaixa.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FluxoDeCaixa.Presentation.Controllers
{
    [Route("fluxo-caixa")]
    public class FluxoCaixaController : ApiController
    {
        private readonly ISender _mediator;

        public FluxoCaixaController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("historico")]
        public async Task<IActionResult> GetHistorico()
        {
            var query = new HistoricoTransacoesQuerie();
            var result = await _mediator.Send(query);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            string jsonString = JsonSerializer.Serialize(result, options);
            return Ok(jsonString);
        }

        [HttpGet("saldo-consolidado")]
        public async Task<IActionResult> GetSaldoConsolidado()
        {
            var query = new SaldoConsolidadoQuerie();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("transacao")]
        public async Task<IActionResult> NovaTransacao(TransacaoRequest transacao)
        {
            var command = new TransacaoCommand(transacao.valor, transacao.isCredito);
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}
