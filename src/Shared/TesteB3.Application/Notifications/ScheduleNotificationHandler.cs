using MassTransit;
using MediatR;
using Serilog;
using TesteB3.Domain.Enums;

namespace TesteB3.Application.Notifications
{
    public class ScheduleNotificationHandler : INotificationHandler<ScheduleNotification>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ScheduleNotificationHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ScheduleNotification notification, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish(notification); 
            Log.Logger.Information($"Schedule Id:{notification.Id} Name:{notification.Description} Succefully {Enum.GetName<EOperation>(notification.Operation)}");
        }
    }
}
