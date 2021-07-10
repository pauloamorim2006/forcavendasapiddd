using SalesForce.Core.Data;
using SalesForce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesForce.Domain.Repositories
{
    public interface IUnidadeRepository : IRepository<Unidade>
    {
        Task<List<Unidade>> RecuperarTodos();
        bool JaExiste(Guid id, string sigla);
        bool Encontrou(Guid id);
    }
}
