using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TesteB3.Application.Behaviors;
using TesteB3.Application.Commands;

namespace TesteB3.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateScheduleCommand).Assembly));
            services.AddAutoMapper(x => x.AddProfile(typeof(MapperProfile)));
            services.AddValidatorsFromAssemblyContaining<CreateScheduleCommandValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}
