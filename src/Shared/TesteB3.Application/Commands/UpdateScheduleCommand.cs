using MediatR;
using System.Text.Json.Serialization;
using TesteB3.Application.Dtos;

namespace TesteB3.Application.Commands
{
    public class UpdateScheduleCommand : IRequest<ScheduleDto>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? Done { get; set; }
        public DateTime? Date { get; set; }

    }
}
