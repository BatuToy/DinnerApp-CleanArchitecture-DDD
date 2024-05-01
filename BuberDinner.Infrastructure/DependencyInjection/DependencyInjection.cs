using System.Text;
using BuberDinner.Application.Common.Intefaces.Authentication;
using BuberDinner.Application.Common.Intefaces.Services;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Infrastructre.Authentication;
using BuberDinner.Infrastructre.Persistence;
using BuberDinner.Infrastructre.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructre;

public static class DependencyInjection 
{
    public static IServiceCollection AddInfrastructure (
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        //services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        //services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider , DateTimeProvider>();
        services.AddSingleton<IUserRepository , UserRepository>();
        return services;
    }


    // AddAuth method is doing the same thing as the commented code above
     public static IServiceCollection AddAuth (
        this IServiceCollection services,
        ConfigurationManager configuration)
        {

        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator , JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audiance,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });
            return services;
        }
}

