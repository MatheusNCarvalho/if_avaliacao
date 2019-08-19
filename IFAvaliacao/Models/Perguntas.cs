namespace IFAvaliacao.Models
{
    public class Perguntas
    {
        public Perguntas(string titulo, string auxiliar1, string auxiliar2, string auxiliar3)
        {
            Titulo = titulo;
            Type = titulo;
            Auxiliar1 = auxiliar1;
            Auxiliar2 = auxiliar2;
            Auxiliar3 = auxiliar3;
            Posicao1 = 1.09;
            Posicao2 = 5.08;
            Posicao3 = 9.0;
            SliderMinimum = 1.0;
        }


        public string Titulo { get; set; }
        public string Type { get; set; }
        public string Auxiliar1 { get; set; }
        public string Auxiliar2 { get; set; }
        public string Auxiliar3 { get; set; }
        public double Posicao1 { get; set; }
        public double Posicao2 { get; set; }
        public double Posicao3 { get; set; }
        public double SliderMinimum { get; set; }

    }
}