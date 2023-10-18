using MassTransit;
using Serilog;
using TesteB3.Application.Notifications;
using TesteB3.Domain.Enums;

namespace TesteB3.WorkerService
{
    public class ScheduleNotificationConsumer : IConsumer<ScheduleNotification>
    {
        public async Task Consume(ConsumeContext<ScheduleNotification> context)
        {
            Log.Logger.Information($"Consumindo a mensagegen de @Operation do Schedule ID: @Id", Enum.GetName<EOperation>(context.Message.Operation), context.Message.Id);
        }
    }
}
