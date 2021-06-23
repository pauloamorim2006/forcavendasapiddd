using FluentValidation.Results;
using System;

namespace ERP.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
        }
        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}