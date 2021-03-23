using FluentValidation;

namespace Entities.Entities.Validations
{
    public class AccountCardValidation : AbstractValidator<AccountCard>
    {
        public AccountCardValidation()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .CreditCard().WithMessage("O campo {PropertyName} deve um numero de cartão valido.");
        }
    }
}
