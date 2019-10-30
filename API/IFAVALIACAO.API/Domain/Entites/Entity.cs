using System;

namespace IFAVALIACAO.API.Domain.Entites
{
    public abstract class Entity
    {
        protected Entity()
        {
             Id  = Guid.NewGuid();   
        }

        public Guid Id { get; protected set; }
    }
}