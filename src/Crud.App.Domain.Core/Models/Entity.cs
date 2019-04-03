using FluentValidation;
using FluentValidation.Results;
using System;

namespace Crud.App.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }

        public abstract bool IsValid();
    }
}
