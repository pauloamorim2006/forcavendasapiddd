using FluentValidation;

namespace SalesForce.Domain.Models.Validations
{
    public class CondicaoPagamentoValidation : AbstractValidator<CondicaoPagamento>
    {
        public CondicaoPagamentoValidation()
        {
            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
