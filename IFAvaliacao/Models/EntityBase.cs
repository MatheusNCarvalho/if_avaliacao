using System;

namespace IFAvaliacao.Models
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; protected set; }
    }
}