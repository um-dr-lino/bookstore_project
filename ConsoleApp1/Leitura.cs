using System;

namespace BookVerse
{
    public class Leitura
    {
        public int LeitorId { get; set; }
        public int LivroId { get; set; }
        public int ClubeLeituraId { get; set; }
        public double Nota { get; set; }
        public DateTime DataLeitura { get; set; }

        public Leitura(int leitorId, int livroId, int clubeLeituraId, double nota)
        {
            LeitorId = leitorId;
            LivroId = livroId;
            ClubeLeituraId = clubeLeituraId;
            Nota = nota;
            DataLeitura = DateTime.Now;
        }
    }
}