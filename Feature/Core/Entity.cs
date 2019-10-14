using FluentValidation.Results;
using System;

namespace Feature.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Entity()
        {
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
