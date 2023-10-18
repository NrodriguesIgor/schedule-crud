using MediatR;
using TesteB3.Application.Notifications;
using TesteB3.Domain.Repositories;

namespace TesteB3.Application.Commands
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand>
    {
        private readonly IPublisher _publisher;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteScheduleCommandHandler(IPublisher publisher, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var scheduleToDelete = await _unitOfWork.Schedules.GetByIdAsync(request.Id);
            if (scheduleToDelete is null)
            {
                throw new FluentValidation.ValidationException("Schedule Not Found");
            }

            _unitOfWork.Schedules.Delete(scheduleToDelete);

            await _unitOfWork.CompleteAsync();

            await _publisher
                .Publish(new ScheduleNotification
                {
                    Description = scheduleToDelete.Description,
                    Id = scheduleToDelete.Id,
                    Operation = Domain.Enums.EOperation.Deleted,
                });
        }
    }
}
