using AutoMapper;
using MediatR;
using TesteB3.Application.Dtos;
using TesteB3.Application.Notifications;
using TesteB3.Domain.Repositories;

namespace TesteB3.Application.Commands
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, ScheduleDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPublisher _publisher;

        public UpdateScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPublisher publisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publisher = publisher;
        }

        async Task<ScheduleDto> IRequestHandler<UpdateScheduleCommand, ScheduleDto>.Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var scheduleToUpdate = await _unitOfWork.Schedules.GetByIdAsync(request.Id);
            if (scheduleToUpdate is null)
            {
                throw new FluentValidation.ValidationException("Schedule Not Found");
            }

            if (!string.IsNullOrEmpty(request.Description))
                scheduleToUpdate.UpdateDescription(request.Description);


            if (request.Done.HasValue)
            {
                if (scheduleToUpdate.Done)
                    throw new FluentValidation.ValidationException("This Schedule Is Already Done");
                else
                    scheduleToUpdate.SetDone(request.Done.Value);
            }
            if(request.Date.HasValue)
            {
                if(request.Date.Value < DateTime.Today)
                    throw new FluentValidation.ValidationException("The Date Must Be Greather Than Today");
                scheduleToUpdate.ChangeDate(request.Date.Value);
            }

            _unitOfWork.Schedules.Update(scheduleToUpdate);

            await _unitOfWork.CompleteAsync();

            await _publisher
                .Publish(new ScheduleNotification
                {
                    Description = request.Description,
                    Id = request.Id,
                    Operation = Domain.Enums.EOperation.Updated
                });

            return _mapper.Map<ScheduleDto>(scheduleToUpdate);
            
        }
    }
}
