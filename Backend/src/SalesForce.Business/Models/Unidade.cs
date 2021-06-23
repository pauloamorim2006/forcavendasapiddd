using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;

namespace ERP.Domain.Models
{
    public class Unidade : Entity
    {
        public string Descricao { get; set; }        
        public string Sigla { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new UnidadeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
