using FluentValidation;
using Bm = BSF.BLL.Abstractions.Dto.StorageBusinessDto;

namespace BSF.BLL.Validating.Validators
{
    /// <summary>
    /// Валидатор для транспортного объекта хранилища
    /// </summary>
    public sealed class StorageValidator : AbstractValidator<Bm>
    {
        /// <summary/>
        public StorageValidator()
        {
            RuleFor(storage => storage.Name).NotEmpty().WithMessage("Имя не должно быть пустым или отсутствующим.");
        }

    }

}
