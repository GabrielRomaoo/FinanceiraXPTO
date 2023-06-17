using FinanceiraXPTO.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceiraXPTO.Dados.Mapping
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeroParcela).IsRequired();
            builder.Property(x => x.ValorParcela).IsRequired();
            builder.Property(x => x.DataPagamento);
            builder.Property(x => x.DataVencimento).IsRequired();
        }
    }
}
