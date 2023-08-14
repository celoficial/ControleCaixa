using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using FluxoDeCaixa.Infrastructure.Data;
using FluxoDeCaixa.Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<IFluxoDeCaixaDbContext, FluxoDeCaixaDbContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                ), ServiceLifetime.Scoped);

            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IFluxoDeCaixaRepository, FluxoDeCaixaRepository>();

            return services;
        }
    }
}
