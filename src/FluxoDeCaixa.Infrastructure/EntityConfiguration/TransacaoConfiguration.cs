using FluxoDeCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoDeCaixa.Infrastructure.EntityConfiguration
{
    internal class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Valor).HasPrecision(14, 2);

            builder.HasOne(t => t.FluxoDeCaixa)
                .WithMany(f => f.Transacoes)
                .HasForeignKey(t => t.FluxoDeCaixaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
