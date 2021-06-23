using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;

namespace ERP.Domain.Models
{
    public class ProdutoServico : Entity
    {
        public string Nome { get; set; }
        public double Estoque { get; set; }
        public double Valor { get; set; }
        public Guid UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
        public bool Ativo { get; set; }
        public bool PermiteFracionar { get; set; }        
        public string CodigoInterno { get; set; }
        
        public override bool EhValido()
        {
            ValidationResult = new ProdutoServicoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
