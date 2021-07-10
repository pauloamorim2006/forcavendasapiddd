using FluentValidation.Results;
using System;

namespace SalesForce.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
        }
        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}