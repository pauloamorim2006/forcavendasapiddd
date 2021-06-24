using ERP.Domain.Models;
using ERP.Domain.Repositories;
using ERP.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infra.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(SalesForceDbContext context) : base(context) { }

        public async Task<Empresa> Buscar()
        {
            return await Db.Empresas.AsNoTracking().Include(x => x.Endereco.Cidade).FirstOrDefaultAsync();
        }
        public bool JaExiste(Guid id, string cnpjCpfDi)
        {
            return Buscar(f => f.CnpjCpfDi == cnpjCpfDi && f.Id != id).Result.Any();
        }
        public bool Encontrou(Guid id)
        {
            return Buscar(f => f.Id == id).Result.Any();
        }
    }
}
