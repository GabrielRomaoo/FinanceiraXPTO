using FinanceiraXPTO.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiraXPTO.Dominio.Entidades
{
    public class ResultadoAnaliseCredito
    {
        public StatusCredito Status { get; set; }
        public decimal ValorCreditoTotalComJuros { get; set; }
        public decimal ValorJurosCredito { get; set; }

    }
}
