using FinanceiraXPTO.Domain.Entidades;
using FinanceiraXPTO.Dominio.Enums;
using FluentValidation;

namespace FinanceiraXPTO.Dominio.Validacoes
{
    public class CreditoValidator : AbstractValidator<Credito>
    {
        public CreditoValidator()
        {
            RuleFor(c => c.ValorCredito).LessThanOrEqualTo(1000000M).WithMessage("Valor máximo do crédito excedido.");
            RuleFor(c => c.QuantidadeParcelas).Must(SaoValidasAsQuantidadesDeParcelas).WithMessage("Quantidades de parcelas inválidas para autorização do crédito.");
            RuleFor(c => c.ValorCredito).Must(EstaDentroValorCreditoMinimoPessoaJuridica).When(x => x.TipoCredito.Tipo == TipoCreditoEnum.PessoaJuridica).WithMessage("Valor do crédito não corresponde ao minimo para a categoria solicitada.");
            RuleFor(c => c.DataPrimeiroVencimento).GreaterThanOrEqualTo(DateTime.Now.AddDays(15)).LessThanOrEqualTo(DateTime.Now.AddDays(45)).WithMessage("Data do primeiro vencimento fora do intervalo.");
        }

        private static bool SaoValidasAsQuantidadesDeParcelas(int quantidadeParcela)
        {
            return (quantidadeParcela >= 5 && quantidadeParcela <= 72);
        }

        private static bool EstaDentroValorCreditoMinimoPessoaJuridica(decimal valorCredito)
        {
            return (valorCredito >= 15000M);
        }
    }
}
