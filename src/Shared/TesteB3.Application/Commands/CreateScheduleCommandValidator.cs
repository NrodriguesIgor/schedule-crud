using FluentValidation;

namespace TesteB3.Application.Commands
{
    public  class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(x => x.Date)
               .GreaterThanOrEqualTo(DateTime.Now);   
        }
    }
}
