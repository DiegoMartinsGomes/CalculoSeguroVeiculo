using CalculoSeguroVeiculo.Infrastructure.Repository;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.DependencyInjection.RepositoryInjection
{
    public class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddTransient<ISeguradoRepository, SeguradoRepository>();
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            services.AddTransient<ISeguroRepository, SeguroRepository>();
        }
    }
}
