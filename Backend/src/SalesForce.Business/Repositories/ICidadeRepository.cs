using SalesForce.Core.Data;
using SalesForce.Domain.Models;
using System;

namespace SalesForce.Domain.Repositories
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        bool JaExiste(Guid id, int codigoIbge);
        bool Encontrou(Guid id);
    }
}