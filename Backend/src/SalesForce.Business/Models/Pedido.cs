using ERP.Core.DomainObjects;
using ERP.Domain.Models.Validations;
using System;
using System.Collections.Generic;

namespace ERP.Domain.Models
{
    public class Pedido: Entity, IAggregateRoot
    {
        protected Pedido()
        {
        }

        public Pedido(Guid id, int codigo, StatusPedido status, Guid clienteId, DateTime data, Guid condicaoPagamentoId, Guid formaPagamentoId)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
            Codigo = codigo;
            Status = status;
            ClienteId = clienteId;
            Data = data;
            CondicaoPagamentoId = condicaoPagamentoId;
            FormaPagamentoId = formaPagamentoId;
            PedidoItens = new List<PedidoItem>();
        }

        public int Codigo { get; private set; }
        public StatusPedido Status { get; private set; } = StatusPedido.Aberto;
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }        
        public DateTime Data { get; private set; }
        public Guid CondicaoPagamentoId { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }        
        public Guid FormaPagamentoId { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public List<PedidoItem> PedidoItens { get; private set; }

        public void SetCodigo(int valor)
        {
            Codigo = valor;
        }

        public void SetStatus(StatusPedido valor)
        {
            if (valor == StatusPedido.Faturado && Status == StatusPedido.Cancelado)
                throw new DomainException("Pedido com status Cancelado não pode ser Faturado!");
            if (valor == StatusPedido.Cancelado && Status == StatusPedido.Faturado)
                throw new DomainException("Pedido com status Faturado não pode ser Cancelado!");
            Status = valor;
        }

        public void SetItem(PedidoItem item)
        {
            PedidoItens.Add(item);
        }

        public override bool EhValido()
        {
            ValidationResult = new PedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
