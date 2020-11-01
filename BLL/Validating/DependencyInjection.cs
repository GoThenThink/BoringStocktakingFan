using BSF.BLL.Abstractions.Dto;
using BSF.BLL.Validating.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BSF.BLL.Validating
{
    internal static class DependencyInjection
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            return services
                .AddSingleton<IValidator<CategoryBusinessDto>, CategoryValidator>()
                .AddSingleton<IValidator<CodePrefixBusinessDto>, CodePrefixValidator>()
                .AddSingleton<IValidator<StorageBusinessDto>, StorageValidator>()
                .AddSingleton<IValidator<ItemBusinessDto>, ItemValidator>()
                .AddSingleton<IValidator<OwnerBusinessDto>, OwnerValidator>();
        }
    }
}
