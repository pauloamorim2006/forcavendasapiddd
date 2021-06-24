using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;

namespace ERP.Domain.Models
{
    public class Unidade : Entity
    {
        protected Unidade ()
        {
        }

        public Unidade(Guid id, string descricao, string sigla)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Descricao = descricao;
            Sigla = sigla;
        }

        public string Descricao { get; private set; }        
        public string Sigla { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new UnidadeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
