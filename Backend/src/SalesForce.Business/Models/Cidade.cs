using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;

namespace ERP.Domain.Models
{
    public class Cidade: Entity, IAggregateRoot
    {
        /*public Cidade(Guid id, int codigoIbge, string descricao, string uf)
        {            
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            CodigoIbge = codigoIbge;
            Descricao = descricao;
            Uf = uf;
        }

        public int CodigoIbge { get; private set; }
        public string Descricao { get; private set; }
        public string Uf { get; private set; }*/

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
