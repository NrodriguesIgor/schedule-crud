using AutoMapper;
using MediatR;
using TesteB3.Application.Notifications;
using TesteB3.Domain.Entitites;
using TesteB3.Domain.Enums;
using TesteB3.Domain.Repositories;

namespace TesteB3.Application.Commands
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IPublisher _publisher;

        public CreateScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPublisher publisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publisher = publisher;
        }

        public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = _mapper.Map<Schedule>(request);

            await _unitOfWork.Schedules.AddAsync(schedule);

            await _unitOfWork.CompleteAsync();

            await _publisher.Publish(new ScheduleNotification 
            { 
                Id = schedule.Id, 
                Description = schedule.Description,
                Operation = EOperation.Created
            });

            return schedule.Id;
        }
    }
}
