using CalculoSeguroVeiculo.Infrastructure.Repository;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.Service.DependencyInjection.RepositoryInjection
{
    public class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
        }
    }
}
