using CalculoSeguroVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculoSeguroVeiculo.Service.DependencyInjection
{
    public class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkOracle()
                .AddDbContext<ReplyContext>(
                    options => options.UseOracle(configuration.GetConnectionString("oracle"))
            );
        }

        //public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        //{
        //    services
        //        .AddEntityFrameworkSqlServer()
        //        .AddDbContext<ReplyContext>(
        //                options => options.UseSqlServer(configuration.GetConnectionString("sqlserver"))
        //        );
        //}
    }
}
