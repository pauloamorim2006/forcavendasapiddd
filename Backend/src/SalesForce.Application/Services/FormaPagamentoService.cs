using SalesForce.Core.Notificacoes;
using SalesForce.Core.Services;
using SalesForce.Domain.Models;
using SalesForce.Domain.Models.Validations;
using SalesForce.Domain.Repositories;
using SalesForce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesForce.Application.Services
{
    public class FormaPagamentoService : BaseService, IFormaPagamentoService
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public FormaPagamentoService(IFormaPagamentoRepository formaPagamentoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        public async Task<bool> Adicionar(FormaPagamento formaPagamento)
        {
            if (!ExecutarValidacao(new FormaPagamentoValidation(), formaPagamento)) return false;

            if (_formaPagamentoRepository.JaExiste(formaPagamento.Id, formaPagamento.Nome))
            {
                Notificar("Já existe uma forma de pagamento com este nome informado.");
                return false;
            }

            await _formaPagamentoRepository.Adicionar(formaPagamento);
            return true;
        }
        public async Task<bool> Atualizar(FormaPagamento formaPagamento)
        {
            if (!ExecutarValidacao(new FormaPagamentoValidation(), formaPagamento)) return false;

            if (_formaPagamentoRepository.JaExiste(formaPagamento.Id, formaPagamento.Nome))
            {
                Notificar("Já existe uma forma de pagamento com este nome informado.");
                return false;
            }

            await _formaPagamentoRepository.Atualizar(formaPagamento);
            return true;
        }
        public async Task<bool> Remover(Guid id)
        {
            if (!_formaPagamentoRepository.Encontrou(id))
            {
                Notificar("Já existe uma forma de pagamento com este nome informado.");
                return false;
            }

            await _formaPagamentoRepository.Remover(id);
            return true;
        }
        public async Task<IEnumerable<FormaPagamento>> Buscar(Expression<Func<FormaPagamento, bool>> predicate)
        {
            return await _formaPagamentoRepository.Buscar(predicate);
        }
        public async Task<FormaPagamento> ObterPorId(Guid id)
        {
            return await _formaPagamentoRepository.ObterPorId(id);
        }
        public async Task<FormaPagamento> Obter(Guid id)
        {
            return await _formaPagamentoRepository.Obter(id);
        }
        public async Task<List<FormaPagamento>> ObterTodos()
        {
            return await _formaPagamentoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _formaPagamentoRepository?.Dispose();
        }
    }
}
