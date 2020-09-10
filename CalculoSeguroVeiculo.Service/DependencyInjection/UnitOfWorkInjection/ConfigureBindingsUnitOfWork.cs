using CalculoSeguroVeiculo.Infrastructure.UnitOfWork;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.Service.DependencyInjection.UnitOfWorkInjection
{
    public class ConfigureBindingsUnitOfWork
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddTransient<ISeguradoUnitOfWork, SeguradoUnitOfWork>();
            services.AddTransient<IVeiculoUnitOfWork, VeiculoUnitOfWork>();
            services.AddTransient<ISeguroUnitOfWork, SeguroUnitOfWork>();
        }
    }
}
