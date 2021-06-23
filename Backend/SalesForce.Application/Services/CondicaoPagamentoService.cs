using ERP.Core.Notificacoes;
using ERP.Core.Services;
using ERP.Domain.Models;
using ERP.Domain.Models.Validations;
using ERP.Domain.Repositories;
using ERP.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class CondicaoPagamentoService : BaseService, ICondicaoPagamentoService
    {
        private readonly ICondicaoPagamentoRepository _condicaoPagamentoRepository;

        public CondicaoPagamentoService(ICondicaoPagamentoRepository condicaoPagamentoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _condicaoPagamentoRepository = condicaoPagamentoRepository;
        }

        public async Task<bool> Adicionar(CondicaoPagamento condicaoPagamento)
        {
            if (!ExecutarValidacao(new CondicaoPagamentoValidation(), condicaoPagamento)) return false;

            if (_condicaoPagamentoRepository.JaExiste(condicaoPagamento.Id, condicaoPagamento.Descricao))
            {
                Notificar("Já existe uma condição de pagamento com esta descrição informada.");
                return false;
            }

            await _condicaoPagamentoRepository.Adicionar(condicaoPagamento);
            return true;
        }
        public async Task<bool> Atualizar(CondicaoPagamento condicaoPagamento)
        {
            if (!ExecutarValidacao(new CondicaoPagamentoValidation(), condicaoPagamento)) return false;

            if (_condicaoPagamentoRepository.JaExiste(condicaoPagamento.Id, condicaoPagamento.Descricao))                
            {
                Notificar("Já existe uma condição de pagamento com esta descrição informada.");
                return false;
            }

            await _condicaoPagamentoRepository.Atualizar(condicaoPagamento);
            return true;
        }
        public async Task<bool> Remover(Guid id)
        {
            if (!_condicaoPagamentoRepository.Encontrou(id))
            {
                Notificar("Já existe uma Condição de Pagamento com este documento informado.");
                return false;
            }
            await _condicaoPagamentoRepository.Remover(id);
            return true;
        }
        public async Task<IEnumerable<CondicaoPagamento>> Buscar(Expression<Func<CondicaoPagamento, bool>> predicate)
        {
            return await _condicaoPagamentoRepository.Buscar(predicate);
        }
        public async Task<CondicaoPagamento> ObterPorId(Guid id)
        {
            return await _condicaoPagamentoRepository.ObterPorId(id);
        }
        public async Task<CondicaoPagamento> Obter(Guid id)
        {
            return await _condicaoPagamentoRepository.Obter(id);
        }
        public async Task<List<CondicaoPagamento>> ObterTodos()
        {
            return await _condicaoPagamentoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _condicaoPagamentoRepository?.Dispose();
        }
    }
}
