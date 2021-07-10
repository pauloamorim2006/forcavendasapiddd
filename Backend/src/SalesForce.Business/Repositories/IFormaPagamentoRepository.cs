using SalesForce.Core.Data;
using SalesForce.Domain.Models;
using System;

namespace SalesForce.Domain.Repositories
{
    public interface IFormaPagamentoRepository : IRepository<FormaPagamento>
    {
        bool JaExiste(Guid id, string nome);
        bool Encontrou(Guid id);
    }
}
