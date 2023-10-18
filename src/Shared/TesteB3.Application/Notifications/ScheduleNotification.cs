using MediatR;
using TesteB3.Domain.Enums;

namespace TesteB3.Application.Notifications
{
    public class ScheduleNotification : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public EOperation Operation { get; set; }
    }


}
