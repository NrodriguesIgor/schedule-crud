using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Infrastruture.Web.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(FluentValidation.ValidationException), HandleValidationException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message, "");
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }



        private void HandleUnknownException(ExceptionContext context)
        {

            Log.Logger.Error(context.Exception, "Fatal Error on Server");

            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Detail = context.Exception.Message
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = (FluentValidation.ValidationException)context.Exception;

            var errors = exception.Errors.GroupBy(x => x.PropertyName).ToList().ToDictionary(x => x.Key, y => y.Select(x => x.ErrorMessage).ToArray());

            ProblemDetails details;

            if (errors.Any())
            {
                details = new ValidationProblemDetails()
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                };

            }
            else
            {
                details = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "An error occurred while processing your request.",
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Detail = context.Exception.Message
                };
            }

            context.Result = new BadRequestObjectResult(details);


            context.ExceptionHandled = true;
        }
    }
}
