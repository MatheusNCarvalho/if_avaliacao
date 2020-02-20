using System;

namespace IFAVALIACAO.API.Models
{
    public class EntityModel
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Deletado { get; set; }
    }
}