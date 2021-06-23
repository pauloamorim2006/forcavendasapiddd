using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;

namespace ERP.Domain.Models
{
    public class Cidade: Entity
    {
        public int CodigoIbge { get; set; }
        public string Descricao { get; set; }
        public string Uf { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new CidadeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
