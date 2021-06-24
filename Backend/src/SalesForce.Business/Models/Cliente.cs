using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using SalesForce.Domain.Models;
using System;

namespace ERP.Domain.Models
{
    public class Cliente: Entity
    {
        protected Cliente()
        {
        }

        public Cliente(Guid id, string nome, string cnpjCpfDi, bool ativo, string tipoPessoa, string telefone, string email, string inscricaoEstadual, int tipoInscricaoEstadual, bool consumidorFinal, Endereco endereco)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Nome = nome;
            CnpjCpfDi = cnpjCpfDi;
            Ativo = ativo;
            TipoPessoa = tipoPessoa;
            Telefone = telefone;
            Email = email;
            InscricaoEstadual = inscricaoEstadual;
            TipoInscricaoEstadual = tipoInscricaoEstadual;
            ConsumidorFinal = consumidorFinal;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public string CnpjCpfDi { get; private set; }        
        public bool Ativo { get; private set; }
        public string TipoPessoa { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public int TipoInscricaoEstadual { get; private set; }
        public bool ConsumidorFinal { get; private set; }
        public Endereco Endereco { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
