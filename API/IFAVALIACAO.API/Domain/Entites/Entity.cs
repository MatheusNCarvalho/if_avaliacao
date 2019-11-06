using System;

namespace IFAVALIACAO.API.Domain.Entites
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
    }
}