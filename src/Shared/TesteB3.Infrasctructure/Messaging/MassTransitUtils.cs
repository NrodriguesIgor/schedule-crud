using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace TesteB3.Infrasctructure.Messaging
{
    public static class MassTransitUtils
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger.Information(Environment.GetEnvironmentVariable("RABBIT_MQ_CONNECTIONSTRING"));
            services.AddMassTransit(x =>
            {
                var entryAssembly = Assembly.GetExecutingAssembly();
                x.AddConsumers(entryAssembly);
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Environment.GetEnvironmentVariable("RABBIT_MQ_CONNECTIONSTRING"));               
                    cfg.ConfigureEndpoints(ctx);
                });
            });

            
        }
    }
}
