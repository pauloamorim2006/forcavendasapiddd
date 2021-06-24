using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;

namespace ERP.Domain.Models
{
    public class PedidoItem: Entity
    {
        public PedidoItem(Guid id, Guid pedidoId, int item, Guid produtoId, double quantidade, double valorUnitario, double valorDesconto, double valorAcrescimo, double valorTotal)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            PedidoId = pedidoId;
            Item = item;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorDesconto = valorDesconto;
            ValorAcrescimo = valorAcrescimo;
            ValorTotal = valorTotal;
        }

        public Guid PedidoId { get; private set; }
        public int Item { get; private set; }
        public Pedido Pedido { get; private set; }
        public Guid ProdutoId { get; private set; }
        public ProdutoServico Produto { get; private set; }
        public double Quantidade { get; private set; }
        public double ValorUnitario { get; private set; }
        public double ValorDesconto { get; private set; }
        public double ValorAcrescimo { get; private set; }
        public double ValorTotal { get; private set; }
        public override bool EhValido()
        {
            ValidationResult = new PedidoItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
