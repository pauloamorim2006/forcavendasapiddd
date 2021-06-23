using ERP.Domain.Models;
using ERP.Domain.Repositories;
using ERP.Infra.Context;
using System;
using System.Linq;

namespace ERP.Infra.Repository
{
    public class CondicaoPagamentoRepository : Repository<CondicaoPagamento>, ICondicaoPagamentoRepository
    {
        public CondicaoPagamentoRepository(SalesForceDbContext context) : base(context) { }

        public bool JaExiste(Guid id, string descricao)
        {
            return Buscar(f => f.Descricao == descricao && f.Id != id).Result.Any();
        }
        public bool Encontrou(Guid id)
        {
            return Buscar(f => f.Id == id).Result.Any();
        }
    }
}
