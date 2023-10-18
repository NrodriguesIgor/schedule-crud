using MediatR;

namespace TesteB3.Application.Commands
{
    public class CreateScheduleCommand : IRequest<int>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; } 
    }
}
