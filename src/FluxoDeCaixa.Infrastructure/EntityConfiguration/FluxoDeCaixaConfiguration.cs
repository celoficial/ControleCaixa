using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoDeCaixa.Infrastructure.EntityConfiguration
{
    internal class FluxoDeCaixaConfiguration : IEntityTypeConfiguration<Domain.Aggregate_Root.FluxoDeCaixa>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregate_Root.FluxoDeCaixa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(f => f.Transacoes)
                   .WithOne(t => t.FluxoDeCaixa);
        }
    }
}
