using ERP.Domain.Models;
using ERP.Domain.Repositories;
using ERP.Infra.Context;
using System;
using System.Linq;

namespace ERP.Infra.Repository
{
    public class FormaPagamentoRepository : Repository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(SalesForceDbContext context) : base(context) { }        
        public bool JaExiste(Guid id, string placa)
        {
            return Buscar(f => f.Nome == placa && f.Id != id).Result.Any();
        }
        public bool Encontrou(Guid id)
        {
            return Buscar(f => f.Id == id).Result.Any();
        }
    }
}
