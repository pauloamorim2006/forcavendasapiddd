using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;

namespace ERP.Domain.Models
{
    public class CondicaoPagamento: Entity
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new CondicaoPagamentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
