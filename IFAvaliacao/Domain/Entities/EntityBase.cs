using SQLite;
using System;

namespace IFAvaliacao.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            DataAtualizacao = DateTime.Now;
        }

        [PrimaryKey]
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public void SetId(string id) => Id = id;

        public void AddDataCriacao() => DataCriacao = DateTime.Now;

        public void AddDataCriacao(DateTime dateTime) => DataCriacao = dateTime;
    }
}