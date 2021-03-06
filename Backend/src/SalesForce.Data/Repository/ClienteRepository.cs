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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SalesForceDbContext context) : base(context) { }
        public async Task<int> RecuperarQuantidade()
        {
            return await Db.Clientes.AsNoTracking().CountAsync();
        }
        public async Task<List<Cliente>> RecuperarTodos()
        {
            return await Db.Clientes
                .Include(x => x.Endereco.Cidade)
                .AsNoTracking()
                .ToListAsync();
        }
        public bool JaExisteCliente(Guid id, string cnpjCpfDi)
        {
            return Buscar(f => f.CnpjCpfDi == cnpjCpfDi && f.Id != id).Result.Any();
        }
        public bool EncontrouCliente(Guid id)
        {
            return Buscar(f => f.Id == id).Result.Any();    
        }
    }
}
