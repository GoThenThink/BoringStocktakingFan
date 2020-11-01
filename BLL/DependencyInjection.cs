using BSF.BLL.Abstractions;
using BSF.BLL.Mapping;
using BSF.BLL.Validating;
using Microsoft.Extensions.DependencyInjection;

namespace BSF.BLL
{
    /// <summary>
    /// Класс для установки уровня бизнес-логики
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Добавляет все компноненты уровня бизнес-логики.
        /// </summary>
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            return services
                .RegisterServices()
                .RegisterValidators()
                .RegisterMapperProfiles();
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IBaseCategoriesService, BaseCategoriesService>()
                .AddScoped<IBaseCodePrefixesService, BaseCodePrefixesService>()
                .AddScoped<IBaseItemsService, BaseItemsService>()
                .AddScoped<IBaseOwnersService, BaseOwnersService>()
                .AddScoped<IBaseStoragesService, BaseStoragesService>();
        }

    }
}
