using FinanceiraXPTO.Domain.Entidades;
using FinanceiraXPTO.Dominio.Entidades;
using FinanceiraXPTO.Dominio.Interfaces;
using FinanceiraXPTO.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiraXPTO.Dominio.Services
{
    public class AnaliseCreditoService : IAnaliseCreditoService
    {
        public async Task<Credito> AnalisarCredito(Credito credito)
        {
            var validation = await new CreditoValidator().ValidateAsync(credito);
            if (validation.IsValid)
            {
                var taxaDeJuros = credito.TipoCredito.TaxaDeJuros / 100;
                credito.AnaliseCredito = new ResultadoAnaliseCredito
                {
                    Status = Enums.StatusCredito.Aprovado,
                    ValorCreditoTotalComJuros = await CalculaValorTotalComJuros(credito.ValorCredito, taxaDeJuros),
                    ValorJurosCredito = await CalculaValorTotalJuros(credito.ValorCredito, taxaDeJuros)
                };

                return credito;
            }

            credito.AnaliseCredito = new ResultadoAnaliseCredito { Status = Enums.StatusCredito.Reprovado, ValorCreditoTotalComJuros = 0M, ValorJurosCredito = 0M };
            return credito;
        }

        public async Task<decimal> CalculaValorTotalComJuros(decimal valorCredito, decimal taxaDeJuros)
        {
            return valorCredito * (1 + taxaDeJuros);
        }

        public async Task<decimal> CalculaValorTotalJuros(decimal valorCredito, decimal taxaDeJuros)
        {
            return valorCredito * taxaDeJuros;
        }
    }

}
