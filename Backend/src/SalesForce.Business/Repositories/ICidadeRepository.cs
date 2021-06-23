using ERP.Core.Data;
using ERP.Domain.Models;
using System;

namespace ERP.Domain.Repositories
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        bool JaExiste(Guid id, int codigoIbge);
        bool Encontrou(Guid id);
    }
}