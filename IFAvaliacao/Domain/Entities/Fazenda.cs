

namespace IFAvaliacao.Domain.Entities
{
    public class Fazenda : EntityBase
    {
        public Fazenda() { }
        public Fazenda(string escricaoEstadual, string nome, string nomeFazenda, string cep, string rua, string bairro, string cidade, string estado)
        {
            EscricaoEstadual = escricaoEstadual;
            Nome = nome;
            NomeFazenda = nomeFazenda;
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public string EscricaoEstadual { get; private set; }
        public string Nome { get; private set; }
        public string NomeFazenda { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

    }
}
