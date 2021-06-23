using ERP.Core.Data;
using ERP.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ERP.Domain.Repositories
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<Empresa> Buscar();
        bool JaExiste(Guid id, string cnpjCpfDi);
        bool Encontrou(Guid id);
    }
}
