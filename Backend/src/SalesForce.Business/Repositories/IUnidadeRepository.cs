using ERP.Core.Data;
using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Domain.Repositories
{
    public interface IUnidadeRepository : IRepository<Unidade>
    {
        Task<List<Unidade>> RecuperarTodos();
        bool JaExiste(Guid id, string sigla);
        bool Encontrou(Guid id);
    }
}
