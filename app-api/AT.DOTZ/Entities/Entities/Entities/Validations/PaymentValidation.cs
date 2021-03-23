using FluentValidation;

namespace Entities.Entities.Validations
{
    public class PaymentValidation : AbstractValidator<Payment>
    {
        public PaymentValidation()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            
            RuleFor(c => c.DocumentCode)
                .NotEmpty().WithMessage("O campo {PropertyName} ser maior que {ComparisonValue}");

           
            RuleFor(c => c.Amount)
                .GreaterThan(0).WithMessage("O campo {PropertyName} ser maior que {ComparisonValue}");

        }
    }
}
