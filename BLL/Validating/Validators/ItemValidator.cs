using FluentValidation;
using Bm = BSF.BLL.Abstractions.Dto.ItemBusinessDto;

namespace BSF.BLL.Validating.Validators
{
    /// <summary>
    /// Валидатор для транспортного объекта хранилища
    /// </summary>
    public sealed class ItemValidator : AbstractValidator<Bm>
    {
        /// <summary/>
        public ItemValidator()
        {
            RuleFor(item => item.Name).NotEmpty().WithMessage("Имя не должно быть пустым или отсутствующим.");
            RuleFor(item => item.Code).MaximumLength(4).WithMessage("Длина кода не должна превышать 4 символа.");
        }

    }

}
