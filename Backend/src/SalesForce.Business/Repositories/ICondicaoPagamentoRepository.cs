using SalesForce.Core.Data;
using SalesForce.Domain.Models;
using System;

namespace SalesForce.Domain.Repositories
{
    public interface ICondicaoPagamentoRepository : IRepository<CondicaoPagamento>
    {
        bool JaExiste(Guid id, string placa);
        bool Encontrou(Guid id);
    }
}
