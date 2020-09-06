using CalculoSeguroVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.Service.DependencyInjection
{
    public class ConfigureBindingsDatabaseContext
    {
        //public static void RegisterBindingsOracle(IServiceCollection services, IConfiguration configuration)
        //{
        //    services
        //        .AddEntityFrameworkOracle()
        //        .AddDbContext<ReplyContext>(
        //            options => options.UseOracle(configuration.GetConnectionString("oracle"))
        //    );
        //}

        public static void RegisterBindingsSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<ReplyContext>(
                        options => options.UseSqlServer(configuration.GetConnectionString("sqlserver"))
                );
        }
    }
}
