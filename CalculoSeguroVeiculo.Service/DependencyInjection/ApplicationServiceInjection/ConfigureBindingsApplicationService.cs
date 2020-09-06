using CalculoSeguroVeiculo.Service.Interfaces;
using CalculoSeguroVeiculo.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.Service.DependencyInjection.ApplicationServiceInjection
{
    public class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddTransient<ISeguradoApplicationService, SeguradoApplicationService>();
            services.AddTransient<IVeiculoApplicationService, VeiculoApplicationService>();
            services.AddTransient<ISeguroApplicationService, SeguroApplicationService>();
        }
    }
}
