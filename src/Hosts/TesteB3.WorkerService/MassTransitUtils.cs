using MassTransit;
using Serilog;
using TesteB3.Infrasctructure.Messaging;
using TesteB3.WorkerService;

namespace TesteB3.WorkerService
{
    public static class MassTransitUtils
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger.Information(Environment.GetEnvironmentVariable("RABBIT_MQ_CONNECTIONSTRING"));
            services.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(ScheduleNotificationConsumer));
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Environment.GetEnvironmentVariable("RABBIT_MQ_CONNECTIONSTRING"));
                    cfg.ConfigureEndpoints(ctx);
                });
            });


        }
    }
}
