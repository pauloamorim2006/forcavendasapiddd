using ERP.Domain.Models;
using ERP.Domain.Repositories;
using ERP.Infra.Context;
using System;
using System.Linq;

namespace ERP.Infra.Repository
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(SalesForceDbContext context) : base(context) { }
        public bool JaExiste(Guid id, int codigoIbge)
        {
            return Buscar(f => f.CodigoIbge == codigoIbge && f.Id != id).Result.Any();
        }
        public bool Encontrou(Guid id)
        {
            return Buscar(f => f.Id == id).Result.Any();
        }
    }
}
