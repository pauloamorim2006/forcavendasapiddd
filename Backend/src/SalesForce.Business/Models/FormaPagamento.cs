using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;

namespace ERP.Domain.Models
{
    public class FormaPagamento: Entity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        // D - Dinheiro, H - Cheque, C - Cartao, V - Vale, R - Crediario, O - Outros 
        public string Tipo { get; set; }        
        public bool Tef { get; set; }
        public bool Credito { get; set; }
        public bool PermitirTroco { get; set; }        
        public string ConfiguracaoFiscal { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new FormaPagamentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
