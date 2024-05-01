using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping;

    public static class DependencyInjection  
    { 
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(DependencyInjection).Assembly);

            services.AddSingleton(config);
            services.AddSingleton<IMapper, ServiceMapper>();
            return services;
        }
    }
