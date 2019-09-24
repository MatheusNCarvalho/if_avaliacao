using System;

namespace IFAvaliacao.Domain.Entities
{
    public class AvaliacaoVaca : EntityBase
    {
        public AvaliacaoVaca() { }

        public AvaliacaoVaca(int nameCow, decimal bodyWight, double angulosiodade, double profundidadeCorporal, double forcaLeiteira, double alturaGarupaHipometro, double comprimentoCorpo, double anguloCarupa, double larguraIleo, double larguraIsquio, double anguloCasco, double jarreteLateral, double jarreteTras, double ubereFirmeza, double uberePosterior, double alturaUbere, double ligamentoCentral, double posicaoTetos)
        {
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
            DataHoraInicio = DateTime.Now;
        }

        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public int NameCow { get; set; }
        public decimal BodyWight { get; set; }

        public double Angulosiodade { get; set; }

        public double ProfundidadeCorporal { get; set; }

        public double ForcaLeiteira { get; set; }

        public double AlturaGarupaHipometro { get; set; }

        public double ComprimentoCorpo { get; set; }

        public double AnguloCarupa { get; set; }

        public double LarguraIleo { get; set; }

        public double LarguraIsquio { get; set; }

        public double AnguloCasco { get; set; }

        public double JarreteLateral { get; set; }

        public double JarreteTras { get; set; }

        public double UbereFirmeza { get; set; }
        public double UberePosterior { get; set; }

        public double AlturaUbere { get; set; }

        public double LigamentoCentral { get; set; }

        public double PosicaoTetos { get; set; }
    }
}