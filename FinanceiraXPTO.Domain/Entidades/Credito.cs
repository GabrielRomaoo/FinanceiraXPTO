using FinanceiraXPTO.Dominio.Entidades;
using FinanceiraXPTO.Dominio.Enums;

namespace FinanceiraXPTO.Domain.Entidades
{
    public class Credito
    {
        public decimal ValorCredito { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public ResultadoAnaliseCredito AnaliseCredito { get; set; }
    }
}
