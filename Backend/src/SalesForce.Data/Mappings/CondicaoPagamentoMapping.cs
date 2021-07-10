using SalesForce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesForce.Infra.Mappings
{
    public class CondicaoPagamentoMapping : IEntityTypeConfiguration<CondicaoPagamento>
    {
        public void Configure(EntityTypeBuilder<CondicaoPagamento> builder)
        {
            builder.ToTable("CondicoesPagamento");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Descricao).IsRequired().HasColumnType("varchar(100)");            
        }
    }
}
