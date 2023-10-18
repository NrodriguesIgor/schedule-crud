using MediatR;

namespace TesteB3.Application.Commands
{
    public class DeleteScheduleCommand : IRequest
    {
        public int Id { get; set; }
    }
}

