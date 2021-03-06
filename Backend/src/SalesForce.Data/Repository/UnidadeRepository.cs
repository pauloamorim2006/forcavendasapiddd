using SalesForce.Domain.Models;
using SalesForce.Domain.Repositories;
using SalesForce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesForce.Infra.Repository
{
    public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(SalesForceDbContext context) : base(context) { }

        public async Task<List<Unidade>> RecuperarTodos()
        {
            return await Db.Unidades
                .AsNoTracking()
                .ToListAsync();
        }
        public bool JaExiste(Guid id, string sigla)
        {
            return Buscar(f => f.Sigla == sigla && f.Id != id).Result.Any();
        }
        public bool Encontrou(Guid id)
        {
            return Buscar(f => f.Id == id).Result.Any();
        }
    }
}
