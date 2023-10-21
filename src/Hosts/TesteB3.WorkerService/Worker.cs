using MassTransit;
using Serilog;
using TesteB3.Application.Notifications;
using TesteB3.Domain.Enums;
using TesteB3.Infrasctructure.Logging;

namespace TesteB3.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Log.Logger.Information($"Worker Running at {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}");
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {

            }

        }

     

        //public class ScheduleNotificationConsumerDefinition : ConsumerDefinition<ScheduleNotificationConsumer>
        //{
        //    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ScheduleNotificationConsumer> consumerConfigurator, IRegistrationContext context)
        //    {
        //        consumerConfigurator.Options<JobOptions<ScheduleNotification>>(options => options
        //            .SetRetry(r => r.Interval(3, TimeSpan.FromSeconds(30)))
        //            .SetJobTimeout(TimeSpan.FromMinutes(10))
        //            .SetConcurrentJobLimit(10));
        //    }
        //}
    }
}