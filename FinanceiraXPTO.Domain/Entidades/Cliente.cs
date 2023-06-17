using FinanceiraXPTO.Dominio.Interfaces;

namespace FinanceiraXPTO.Dominio.Entidades
{
    public class Cliente : IEntidade
    {
        public string? NomeCliente { get; set; }
        public string? CPF { get; set; }
        public string? UF { get; set;}
        public string? NumeroCelular { get; set; }
        public ICollection<Financiamento> Financiamentos { get; set; }
    }
}
