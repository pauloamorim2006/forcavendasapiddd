using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;

namespace ERP.Domain.Models
{
    public class ProdutoServico : Entity
    {
        protected ProdutoServico()
        {
        }

        public ProdutoServico(Guid id, string nome, double estoque, double valor, Guid unidadeId, bool ativo, bool permiteFracionar, string codigoInterno)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            UnidadeId = unidadeId;
            Ativo = ativo;
            PermiteFracionar = permiteFracionar;
            CodigoInterno = codigoInterno;
        }

        public string Nome { get; private set; }
        public double Estoque { get; private set; }
        public double Valor { get; private set; }
        public Guid UnidadeId { get; private set; }
        public Unidade Unidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool PermiteFracionar { get; private set; }        
        public string CodigoInterno { get; private set; }
        
        public override bool EhValido()
        {
            ValidationResult = new ProdutoServicoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
