using AutoMapper;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Connection;
using BSF.DAL.Connection;
using BSF.DAL.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace BSF.DAL
{
    /// <summary>
    /// Класс для установки уровня доступа к данным
    /// </summary>
    public static class DependencyInjection
    {
        ///<summary>
        /// Добавление всех компонентов уровня.
        /// </summary>
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString)
        {
            return services
                .AddSingleton<IDbConnectionFactory>(new DbConnectionFactory(connectionString))
                .RegisterMapperProfiles()
                .RegisterRepositories();
        }

        private static IServiceCollection RegisterRepositories(
            this IServiceCollection services)
        {
            return services
                .AddSingleton<IBaseCodePrefixesRepo, BaseCodePrefixesRepo>()
                .AddSingleton<IBaseCategoriesRepo, BaseCategoriesRepo>()
                .AddSingleton<IBaseStoragesRepo, BaseStoragesRepo>()
                .AddSingleton<IBaseItemsRepo, BaseItemsRepo>()
                .AddSingleton<IBaseOwnersRepo, BaseOwnersRepo>();
        }

        private static IServiceCollection RegisterMapperProfiles(
            this IServiceCollection services)
        {
            return services
                .AddSingleton<Profile, CodePrefixEntityProfile>()
                .AddSingleton<Profile, CategoryEntityProfile>()
                .AddSingleton<Profile, StorageEntityProfile>()
                .AddSingleton<Profile, OwnerEntityProfile>()
                .AddSingleton<Profile, ItemEntityProfile>();
        }
    }
}
