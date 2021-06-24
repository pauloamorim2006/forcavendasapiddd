using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(60);
            builder.Property(c => c.Fantasia).IsRequired().HasMaxLength(60);
            builder.Property(c => c.CnpjCpfDi).IsRequired();
            builder.Property(c => c.Ativo);
            builder.Property(c => c.TipoPessoa).IsRequired();
            builder.Property(c => c.Telefone);
            builder.Property(c => c.Email);
            builder.Property(c => c.InscricaoEstadual);
            builder.Property(c => c.TipoInscricaoEstadual).IsRequired();
            builder.Property(c => c.Padrao);
            builder.Property(c => c.Crt).IsRequired();

            builder.OwnsOne(c => c.Endereco, cm =>
            {
                cm.Property(c => c.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasColumnType("varchar(60)")
                    .IsRequired()
                    .HasMaxLength(60);

                cm.Property(c => c.Numero)
                    .HasColumnName("Numero")
                    .HasColumnType("varchar(60)")
                    .IsRequired()
                    .HasMaxLength(60);

                cm.Property(c => c.Bairro)
                    .HasColumnName("Bairro")
                    .HasColumnType("varchar(60)")
                    .IsRequired()
                    .HasMaxLength(60);

                cm.Property(c => c.Cep)
                    .HasColumnName("Cep")
                    .HasColumnType("varchar(20)")
                    .IsRequired()
                    .HasMaxLength(60);

                cm.Property(c => c.Complemento)
                    .HasColumnName("Complemento")
                    .HasColumnType("varchar(100)")
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
