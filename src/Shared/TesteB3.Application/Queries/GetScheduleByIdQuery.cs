using MediatR;
using TesteB3.Application.Dtos;

namespace TesteB3.Application.Queries
{
    public class GetScheduleByIdQuery : IRequest<ScheduleDto>
    {
        public int Id { get; set; }
    }
}
