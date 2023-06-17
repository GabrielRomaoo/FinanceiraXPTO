using FinanceiraXPTO.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace FinanceiraXPTO.Dados.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeroCelular).IsRequired();
            builder.Property(x => x.CPF).IsRequired();
            builder.Property(x => x.NomeCliente).IsRequired();
            builder.Property(x => x.UF).IsRequired();
            builder.HasMany<Financiamento>(f => f.Financiamentos)
                .WithOne(f => f.Cliente)
                .HasForeignKey(f => f.ClienteId);
        }
    }
}
