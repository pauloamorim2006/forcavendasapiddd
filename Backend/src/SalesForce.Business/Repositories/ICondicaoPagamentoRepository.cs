using ERP.Core.Data;
using ERP.Domain.Models;
using System;

namespace ERP.Domain.Repositories
{
    public interface ICondicaoPagamentoRepository : IRepository<CondicaoPagamento>
    {
        bool JaExiste(Guid id, string placa);
        bool Encontrou(Guid id);
    }
}
