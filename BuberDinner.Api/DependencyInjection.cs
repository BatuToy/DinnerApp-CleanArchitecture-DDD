namespace BuberDinner.Api;
using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;

public static class DependencyInjection 
{
    public static IServiceCollection AddPresentation (this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<BuberDinnerProblemDetailsFactory , BuberDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}