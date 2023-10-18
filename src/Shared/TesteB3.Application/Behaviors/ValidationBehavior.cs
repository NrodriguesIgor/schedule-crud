using FluentValidation;
using MediatR;

namespace TesteB3.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
          where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)));

                var errorsDictionary = validationResults
                    .Where(r => r.Errors.Any())
                    .SelectMany(x => x.Errors)
                    .Where(x => x != null);

                if (errorsDictionary.Any())
                {
                    throw new ValidationException(errorsDictionary);
                }

            }
            return await next();
        }
    }
}
