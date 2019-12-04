using System;

namespace IFAVALIACAO.API.Domain.Entites
{
    public class Fazenda : Entity
    {
        protected Fazenda() { }

        public Fazenda(string nomeProprietario, string nomeFazenda, string inscricaoEstadual, string cep, string endereco, string cidade, string estado, Guid? id = null)
        {
            if (id.HasValue)
            {
                Id = id.Value;
            }
            NomeProprietario = nomeProprietario;
            NomeFazenda = nomeFazenda;
            InscricaoEstadual = inscricaoEstadual;
            Cep = cep;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
        }

        public string NomeProprietario { get; private set; }
        public string NomeFazenda { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public void SetNomeProprietario(string nomeProprietario)
        {
            NomeProprietario = nomeProprietario;
        }

        public void SetNomeFazenda(string nomeFazenda)
        {
            NomeFazenda = nomeFazenda;
        }

        public void SetInscricaoEstadual(string inscricaoEstadual)
        {
            InscricaoEstadual = inscricaoEstadual;
        }

        public void SetEndereco(string endereco)
        {
            Endereco = endereco;
        }

        public void SetCidade(string cidade)
        {
            Cidade = cidade;
        }

        public void SetEstado(string estado)
        {
            Estado = estado;
        }
    }
}