using ERP.Core.Data;
using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Domain.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Cliente>> RecuperarTodos();
        Task<int> RecuperarQuantidade();
        bool JaExisteCliente(Guid id, string cnpjCpfDi);
        bool EncontrouCliente(Guid id);
    }
}
