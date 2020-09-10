﻿using CalculoSeguroVeiculo.DependencyInjection.ApplicationServiceInjection;
using CalculoSeguroVeiculo.DependencyInjection.RepositoryInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.DependencyInjection
{
    public static class ConfigureBindingsDependencyInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsDatabaseContext.RegisterBindings(services, configuration);
            ConfigureBindingsApplicationService.RegisterBindings(services);
            ConfigureBindingsRepository.RegisterBindings(services);
        }
    }
}