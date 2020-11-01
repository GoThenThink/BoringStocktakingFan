using FluentValidation;
using Bm = BSF.BLL.Abstractions.Dto.CategoryBusinessDto;

namespace BSF.BLL.Validating.Validators
{
    /// <summary>
    /// Валидатор для транспортного объекта категории
    /// </summary>
    public sealed class CategoryValidator : AbstractValidator<Bm>
    {
        /// <summary/>
        public CategoryValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Имя не должно быть пустым или отсутствующим.");
        }

    }

}
