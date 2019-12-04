using System;

namespace IFAVALIACAO.API.Domain.Entites
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime? DataAtualizacao { get; protected set; }

        public void SetDataCriacao(DateTime dataCriacao)
        {
            DataCriacao = dataCriacao;
        }

        public void SetDataAtualizacao(DateTime? dataAtualizacao)
        {
            DataAtualizacao = dataAtualizacao;
        }
    }
}