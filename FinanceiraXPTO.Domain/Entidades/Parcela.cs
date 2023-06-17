using FinanceiraXPTO.Dominio.Interfaces;

namespace FinanceiraXPTO.Dominio.Entidades
{
    public class Parcela : IEntidade
    {
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int FinanciamentoId { get; set; }
        public virtual Financiamento Financiamento { get; set; }
    }
}
