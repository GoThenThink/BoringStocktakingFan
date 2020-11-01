using AutoMapper;
using BSF.BLL.Mapping.Profiles;
using BSF.DAL.Mapping.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace BSF.BLL.Mapping
{
    internal static class DependencyInjection
    {
        public static IServiceCollection RegisterMapperProfiles(this IServiceCollection services)
        {
            return services
                .AddSingleton<Profile, CodePrefixBusinessProfile>()
                .AddSingleton<Profile, CategoryBusinessProfile>()
                .AddSingleton<Profile, StorageBusinessProfile>()
                .AddSingleton<Profile, OwnerBusinessProfile>()
                .AddSingleton<Profile, ItemBusinessProfile>();
        }
    }
}
