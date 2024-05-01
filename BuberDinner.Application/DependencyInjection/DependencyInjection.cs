using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Common.Behaviours;
using BuberDinner.Application.Authentication.Commons;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;

namespace BuberDinner.Application;

public static class DependencyInjection 
{
    public static IServiceCollection AddApplication (this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>) ,typeof(ValidationBehaviour<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}