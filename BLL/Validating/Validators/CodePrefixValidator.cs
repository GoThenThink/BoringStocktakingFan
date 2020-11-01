using FluentValidation;
using Bm = BSF.BLL.Abstractions.Dto.CodePrefixBusinessDto;

namespace BSF.BLL.Validating.Validators
{
    /// <summary>
    /// Валидатор для транспортного объекта кода-префикса
    /// </summary>
    public sealed class CodePrefixValidator : AbstractValidator<Bm>
    {
        /// <summary/>
        public CodePrefixValidator()
        {
            RuleFor(codePrefix => codePrefix.Code).NotEmpty().WithMessage("Код не должно быть пустым или отсутствующим.").MaximumLength(2).WithMessage("Предельная длина код-префикса - 2 символа.");
        }

    }

}
