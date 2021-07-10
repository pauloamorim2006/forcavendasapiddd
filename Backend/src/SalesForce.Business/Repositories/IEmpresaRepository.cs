using SalesForce.Core.Data;
using SalesForce.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SalesForce.Domain.Repositories
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<Empresa> Buscar();
        bool JaExiste(Guid id, string cnpjCpfDi);
        bool Encontrou(Guid id);
    }
}
