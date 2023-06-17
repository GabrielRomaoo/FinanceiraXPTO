using FinanceiraXPTO.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiraXPTO.Dados.Mapping
{
    public class FinanciamentoMap : IEntityTypeConfiguration<Financiamento>
    {
        public void Configure(EntityTypeBuilder<Financiamento> builder)
        {
            builder.ToTable("Financiamento", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CPF).IsRequired();
            builder.Property(x => x.TipoFinanciamento).IsRequired();
            builder.Property(x => x.DataUltimoVencimento); 
            builder.Property(x => x.ValorTotal).IsRequired(); 
            builder.HasMany<Parcela>(p => p.Parcelas)
                .WithOne(f => f.Financiamento)
                .HasForeignKey(f => f.FinanciamentoId);
        }
    }
}
