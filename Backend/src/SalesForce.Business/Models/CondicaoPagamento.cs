using SalesForce.Core.DomainObjects;
using SalesForce.Domain.Models.Validations;
using System;

namespace SalesForce.Domain.Models
{
    public class CondicaoPagamento: Entity
    {
        protected CondicaoPagamento()
        {
        }

        public CondicaoPagamento(Guid id, string descricao, string nome)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Descricao = descricao;
            Nome = nome;
        }

        public string Descricao { get; private set; }
        public string Nome { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new CondicaoPagamentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
