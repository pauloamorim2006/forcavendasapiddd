using ERP.Core.Data;
using ERP.Domain.Models;
using System;

namespace ERP.Domain.Repositories
{
    public interface IFormaPagamentoRepository : IRepository<FormaPagamento>
    {
        bool JaExiste(Guid id, string nome);
        bool Encontrou(Guid id);
    }
}
