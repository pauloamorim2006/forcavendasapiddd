using SalesForce.Core.DomainObjects;
using SalesForce.Domain.Models.Validations;
using System;

namespace SalesForce.Domain.Models
{
    public class FormaPagamento: Entity
    {
        protected FormaPagamento()
        {
        }

        public FormaPagamento(Guid id, string nome, bool ativo, string tipo, bool tef, bool credito, bool permitirTroco, string configuracaoFiscal)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Nome = nome;
            Ativo = ativo;
            Tipo = tipo;
            Tef = tef;
            Credito = credito;
            PermitirTroco = permitirTroco;
            ConfiguracaoFiscal = configuracaoFiscal;
        }

        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        // D - Dinheiro, H - Cheque, C - Cartao, V - Vale, R - Crediario, O - Outros 
        public string Tipo { get; private set; }        
        public bool Tef { get; private set; }
        public bool Credito { get; private set; }
        public bool PermitirTroco { get; private set; }        
        public string ConfiguracaoFiscal { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new FormaPagamentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
