using FluentValidation;

namespace Entities.Entities.Validations
{
    public class AccountExtractValidation : AbstractValidator<AccountExtract>
    {
        public AccountExtractValidation()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            
            RuleFor(c => c.Peso)
                .GreaterThan(0).WithMessage("O campo {PropertyName} ser maior que {ComparisonValue}");

            RuleFor(c => c.Dotz)
                .GreaterThan(0).WithMessage("O campo {PropertyName} ser maior que {ComparisonValue}");

            RuleFor(c => c.Amount)
                .GreaterThan(0).WithMessage("O campo {PropertyName} ser maior que {ComparisonValue}");

        }
    }
}
