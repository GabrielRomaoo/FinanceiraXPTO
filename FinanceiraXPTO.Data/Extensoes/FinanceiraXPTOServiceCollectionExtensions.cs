using FinanceiraXPTO.Dados.Contexto;
using FinanceiraXPTO.Dominio.Interfaces;
using FinanceiraXPTO.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceiraXPTO.Dados.Extensions
{
    public static class FinanceiraXPTOServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAnaliseCreditoService, AnaliseCreditoService>();
            return services;
        }

        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinanceiraXPTOContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FinanceiraXPTO"));
            });
            return services;
        }
    }
}
