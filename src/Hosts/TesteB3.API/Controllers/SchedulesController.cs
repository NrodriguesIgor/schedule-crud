using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteB3.Application.Commands;
using TesteB3.Application.Dtos;
using TesteB3.Application.Queries;

namespace TesteB3.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class SchedulesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public SchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<ScheduleDto>))]
        public async Task<IActionResult> GetList([FromQuery] ListScheduleQuery listScheduleQuery)
        {
            var response = await _mediator.Send(listScheduleQuery);
            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ScheduleDto))]
        public async Task<IActionResult> GetById([FromRoute] GetScheduleByIdQuery getScheduleByIdQuery)
        {
            var response = await _mediator.Send(getScheduleByIdQuery);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleCommand createScheduleCommand)
        {
            var response = await _mediator.Send(createScheduleCommand);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateSchedule([FromBody] UpdateScheduleCommand command, [FromRoute] int id)
        {
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteSchedule([FromRoute] DeleteScheduleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
