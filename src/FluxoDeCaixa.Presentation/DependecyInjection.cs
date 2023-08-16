using FluxoDeCaixa.Presentation.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FluxoDeCaixa.Presentation
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSingleton<ProblemDetailsFactory, FluxoDeCaixaProblemDetailsFactory>();
            return services;
        }
    }
}
