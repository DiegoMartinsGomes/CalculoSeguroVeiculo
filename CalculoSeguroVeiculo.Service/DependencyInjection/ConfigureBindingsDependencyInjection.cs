using CalculoSeguroVeiculo.Service.DependencyInjection.ApplicationServiceInjection;
using CalculoSeguroVeiculo.Service.DependencyInjection.RepositoryInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.Service.DependencyInjection
{
    public static class ConfigureBindingsDependencyInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsDatabaseContext.RegisterBindingsSqlServer(services, configuration);
            ConfigureBindingsApplicationService.RegisterBindings(services);
            ConfigureBindingsRepository.RegisterBindings(services);
        }
    }
}
