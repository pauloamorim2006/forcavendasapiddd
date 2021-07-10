using SalesForce.Core.DomainObjects;
using SalesForce.Domain.Models.Validations;
using System;

namespace SalesForce.Domain.Models
{
    public class Cidade: Entity
    {
        protected Cidade()
        {
        }

        public Cidade(Guid id, int codigoIbge, string descricao, string uf)
        {            
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            CodigoIbge = codigoIbge;
            Descricao = descricao;
            Uf = uf;
        }

        public int CodigoIbge { get; private set; }
        public string Descricao { get; private set; }
        public string Uf { get; private set; }
      
        public override bool EhValido()
        {
            ValidationResult = new CidadeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
