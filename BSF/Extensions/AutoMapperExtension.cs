using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BSF.Extensions
{
    internal static class AutoMapperExtension
    {
        internal static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            return services
                .AddSingleton(provider =>
                {
                    var configuration = new MapperConfiguration(cfg => {
                        cfg.AddProfiles(provider.GetServices<Profile>());
                    });

                    configuration.AssertConfigurationIsValid();
                    return configuration.CreateMapper(provider.GetService);
                });
        }
    }
}
