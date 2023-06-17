using FinanceiraXPTO.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiraXPTO.Dominio.Entidades
{
    public class TipoCredito
    {   
        public string DescricaoCredito { get; set; }
        public TipoCreditoEnum Tipo { get; set; }
        public decimal TaxaDeJuros { get; set; }
    }
}
