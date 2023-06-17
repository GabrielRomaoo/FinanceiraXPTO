using FinanceiraXPTO.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiraXPTO.Dados.Contexto
{
    public class FinanceiraXPTOContext : DbContext
    {
        public FinanceiraXPTOContext(DbContextOptions<FinanceiraXPTOContext> options)
        : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cliente> Financiamentos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        
    }
}
