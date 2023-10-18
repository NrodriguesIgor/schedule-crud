using AutoMapper;
using MediatR;
using TesteB3.Application.Dtos;
using TesteB3.Domain.Repositories;

namespace TesteB3.Application.Queries
{
    public class ListScheduleQueryHandler : IRequestHandler<ListScheduleQuery, IReadOnlyCollection<ScheduleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListScheduleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ScheduleDto>> Handle(ListScheduleQuery request, CancellationToken cancellationToken)
        {
            var schedules = await _unitOfWork.Schedules.ListAsync(x => true, asNoTracking: true);

            if (!string.IsNullOrWhiteSpace(request.Description))
                schedules = schedules.Where(x => x.Description.Contains(request.Description));

            if (request.InitialDate.HasValue)
                schedules = schedules.Where(x => x.Date >= request.InitialDate);

            if (request.FinalDate.HasValue)
                schedules = schedules.Where(x => x.Date <= request.FinalDate);

            if (request.Done.HasValue)
                schedules = schedules.Where(x => x.Done == request.Done);

            return schedules.Select(x => _mapper.Map<ScheduleDto>(x)).ToList();
        }
    }
}
