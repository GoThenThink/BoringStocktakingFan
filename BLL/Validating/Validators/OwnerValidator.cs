using FluentValidation;
using Bm = BSF.BLL.Abstractions.Dto.OwnerBusinessDto;

namespace BSF.BLL.Validating.Validators
{
    /// <summary>
    /// Валидатор для транспортного объекта владельца предмета
    /// </summary>
    public sealed class OwnerValidator : AbstractValidator<Bm>
    {
        /// <summary/>
        public OwnerValidator()
        {
            RuleFor(owner => owner.Name).NotEmpty().WithMessage("Имя не должно быть пустым или отсутствующим.");
        }

    }

}
