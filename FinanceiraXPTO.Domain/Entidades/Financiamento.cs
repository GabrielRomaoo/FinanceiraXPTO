using FinanceiraXPTO.Dominio.Enums;
using FinanceiraXPTO.Dominio.Interfaces;

namespace FinanceiraXPTO.Dominio.Entidades
{
    public class Financiamento : IEntidade
    {
        public string CPF { get; set; } = new string(String.Empty);
        public TipoFinanciamentoEnum TipoFinanciamento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime? DataUltimoVencimento { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public ICollection<Parcela> Parcelas { get; set; }
    }
}
