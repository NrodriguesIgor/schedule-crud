using AutoMapper;
using MediatR;
using TesteB3.Application.Dtos;
using TesteB3.Domain.Repositories;

namespace TesteB3.Application.Queries
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery,ScheduleDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetScheduleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<ScheduleDto> IRequestHandler<GetScheduleByIdQuery, ScheduleDto>.Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _unitOfWork.Schedules.GetByIdAsync(request.Id);

            return _mapper.Map<ScheduleDto>(schedule);
        }
    }
}
