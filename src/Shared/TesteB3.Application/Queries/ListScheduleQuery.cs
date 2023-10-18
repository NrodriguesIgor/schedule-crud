using MediatR;
using TesteB3.Application.Dtos;

namespace TesteB3.Application.Queries
{
    public class ListScheduleQuery : IRequest<IReadOnlyCollection<ScheduleDto>>
    {
        public string? Description { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public bool? Done { get; set; }
    }
}
