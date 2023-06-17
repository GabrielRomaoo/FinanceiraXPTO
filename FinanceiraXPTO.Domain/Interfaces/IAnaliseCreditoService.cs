using FinanceiraXPTO.Domain.Entidades;

namespace FinanceiraXPTO.Dominio.Interfaces
{
    public interface IAnaliseCreditoService
    {
        Task<Credito> AnalisarCredito(Credito credito);
        Task<decimal> CalculaValorTotalComJuros(decimal valorCredito, decimal taxaDeJuros);
        Task<decimal> CalculaValorTotalJuros(decimal valorCredito, decimal taxaDeJuros);
    }
}
