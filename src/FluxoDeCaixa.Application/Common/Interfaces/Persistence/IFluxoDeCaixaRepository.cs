using Microsoft.EntityFrameworkCore.Storage;

namespace FluxoDeCaixa.Application.Common.Interfaces.Persistence
{
    public interface IFluxoDeCaixaRepository
    {
        decimal CalcularConsolidadoTotal();
        Task<FluxoDeCaixa.Domain.Aggregate_Root.FluxoDeCaixa?> ObterFluxoDeCaixaPorData(DateTime data);
        Task AdicionarFluxoDeCaixaAsync(FluxoDeCaixa.Domain.Aggregate_Root.FluxoDeCaixa fluxoDeCaixa);
        Task<List<Domain.Aggregate_Root.FluxoDeCaixa>> ObterTodosOsFluxosDeCaixaAsync();
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
    }
}
