using System;

namespace IFAVALIACAO.API.Domain.Entites
{
    public class Avaliacao : Entity
    {
        protected Avaliacao() { }

        public Avaliacao(DateTime dataHoraInicio,
            DateTime dataHoraFim,
            int nameCow,
            decimal bodyWight,
            int angulosiodade,
            int profundidadeCorporal,
            int forcaLeiteira,
            int alturaGarupaHipometro,
            int comprimentoCorpo,
            int anguloCarupa,
            int larguraIleo,
            int larguraIsquio,
            int anguloCasco,
            int jarreteLateral,
            int jarreteTras,
            int ubereFirmeza,
            int uberePosterior,
            int alturaUbere,
            int ligamentoCentral,
            int posicaoTetos,
            Guid userId)
        {
            UserId = userId;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            NameCow = nameCow;
            BodyWight = bodyWight;
            Angulosiodade = angulosiodade;
            ProfundidadeCorporal = profundidadeCorporal;
            ForcaLeiteira = forcaLeiteira;
            AlturaGarupaHipometro = alturaGarupaHipometro;
            ComprimentoCorpo = comprimentoCorpo;
            AnguloCarupa = anguloCarupa;
            LarguraIleo = larguraIleo;
            LarguraIsquio = larguraIsquio;
            AnguloCasco = anguloCasco;
            JarreteLateral = jarreteLateral;
            JarreteTras = jarreteTras;
            UbereFirmeza = ubereFirmeza;
            UberePosterior = uberePosterior;
            AlturaUbere = alturaUbere;
            LigamentoCentral = ligamentoCentral;
            PosicaoTetos = posicaoTetos;
        }
        public DateTime DataHoraInicio { get; private set; }
        public DateTime DataHoraFim { get; private set; }
        public int NameCow { get; private set; }
        public decimal BodyWight { get; private set; }

        public int Angulosiodade { get; private set; }

        public int ProfundidadeCorporal { get; private set; }

        public int ForcaLeiteira { get; private set; }

        public int AlturaGarupaHipometro { get; private set; }

        public int ComprimentoCorpo { get; private set; }

        public int AnguloCarupa { get; private set; }

        public int LarguraIleo { get; private set; }

        public int LarguraIsquio { get; private set; }

        public int AnguloCasco { get; private set; }

        public int JarreteLateral { get; private set; }

        public int JarreteTras { get; private set; }

        public int UbereFirmeza { get; private set; }
        public int UberePosterior { get; private set; }

        public int AlturaUbere { get; private set; }

        public int LigamentoCentral { get; private set; }

        public int PosicaoTetos { get; private set; }
    }
}