using API.Improvements.Application.Authentication.Commands.Register;
using API.Improvements.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Improvements.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(AssemblyReference.Assembly));
            services.AddScoped(
                typeof(IPipelineBehavior<,>), 
                typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(AssemblyReference.Assembly);
            return services;
        }
    }
}
