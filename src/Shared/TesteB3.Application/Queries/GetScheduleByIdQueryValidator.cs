using FluentValidation;

namespace TesteB3.Application.Queries
{
    public class GetScheduleByIdQueryValidator : AbstractValidator<GetScheduleByIdQuery>
    {
        public GetScheduleByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0); 
        }
    }
}
