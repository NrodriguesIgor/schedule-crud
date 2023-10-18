using FluentValidation;

namespace TesteB3.Application.Queries
{
    public class ListScheduleQueryValidator : AbstractValidator<ListScheduleQuery>
    {
        public ListScheduleQueryValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(10)
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.InitialDate)
                .GreaterThanOrEqualTo(x => x.FinalDate)
               ;// .When(x => (x.InitialDate.HasValue && x.FinalDate.HasValue));
        }
    }
}
