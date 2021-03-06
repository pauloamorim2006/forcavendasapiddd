using SalesForce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesForce.Domain.Services
{
    public interface ICondicaoPagamentoService
    {
        Task<IEnumerable<CondicaoPagamento>> Buscar(Expression<Func<CondicaoPagamento, bool>> predicate);
        Task<CondicaoPagamento> ObterPorId(Guid id);
        Task<CondicaoPagamento> Obter(Guid id);
        Task<List<CondicaoPagamento>> ObterTodos();
        Task<bool> Adicionar(CondicaoPagamento condicaoPagamento);
        Task<bool> Atualizar(CondicaoPagamento condicaoPagamento);
        Task<bool> Remover(Guid id);
    }
}
