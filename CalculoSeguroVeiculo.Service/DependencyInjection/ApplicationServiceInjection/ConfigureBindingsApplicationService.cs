using CalculoSeguroVeiculo.Service.Interfaces;
using CalculoSeguroVeiculo.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.Service.DependencyInjection.ApplicationServiceInjection
{
    public class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IVeiculoApplicationService, VeiculoApplicationService>();
        }
    }
}
