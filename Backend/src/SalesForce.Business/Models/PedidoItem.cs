using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;

namespace ERP.Domain.Models
{
    public class PedidoItem: Entity
    {
        public Guid PedidoId { get; set; }
        public int Item { get; set; }
        public Pedido Pedido { get; set; }
        public Guid ProdutoId { get; set; }
        public ProdutoServico Produto { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorAcrescimo { get; set; }
        public double ValorTotal { get; set; }
        public override bool EhValido()
        {
            ValidationResult = new PedidoItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
