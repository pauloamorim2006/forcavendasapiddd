using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using SalesForce.Domain.Models;
using System;

namespace ERP.Domain.Models
{
    public class Empresa: Entity, IAggregateRoot
    {
        protected Empresa()
        {
        }

        public Empresa(Guid id, string nome, string fantasia, string cnpjCpfDi, string tipoPessoa, string telefone, string email, string inscricaoEstadual, int tipoInscricaoEstadual, int crt, Endereco endereco)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Nome = nome;
            Fantasia = fantasia;
            CnpjCpfDi = cnpjCpfDi;
            TipoPessoa = tipoPessoa;
            Telefone = telefone;
            Email = email;
            InscricaoEstadual = inscricaoEstadual;
            TipoInscricaoEstadual = tipoInscricaoEstadual;            
            Crt = crt;
            Endereco = endereco;
            Ativo = true;
            Padrao = true;
        }

        public string Nome { get; private set; }
        public string Fantasia { get; private set; }
        public string CnpjCpfDi { get; private set; }        
        public bool Ativo { get; private set; }
        public string TipoPessoa { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public int TipoInscricaoEstadual { get; private set; }
        public bool Padrao { get; private set; }
        public int Crt { get; private set; }
        public Endereco Endereco { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new EmpresaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
