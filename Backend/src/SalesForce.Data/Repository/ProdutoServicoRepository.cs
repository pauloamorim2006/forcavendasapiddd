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
    public class ProdutoServicoRepository : Repository<ProdutoServico>, IProdutoServicoRepository
    {
        public ProdutoServicoRepository(SalesForceDbContext context) : base(context) {}

        public async Task<List<ProdutoServico>> RecuperarTodos()
        {
            return await Db.ProdutosServicos
                .Include(x => x.Unidade)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<int> RecuperarQuantidade()
        {
            return await Db.ProdutosServicos.AsNoTracking().CountAsync();
        }
        public bool JaExiste(Guid id, string nome)
        {
            return Buscar(f => f.Nome == nome && f.Id != id).Result.Any();
        }
        public bool Encontrou(Guid id)
        {
            return Buscar(f => f.Id == id).Result.Any();
        }
    }
}
