using System;

namespace BookVerse
{
    public class Leitura
    {
        public int Id { get; set; }
        public float Nota { get; set; }
        public string Comentario { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public int LeitorId { get; set; }
        public int LivroId { get; set; }
        public int ClubeId { get; set; }

        public Leitura(int leitorId, int livroId, int clubeId, float nota, string comentario)
        {
            LeitorId = leitorId;
            LivroId = livroId;
            ClubeId = clubeId;
            Nota = nota;
            Comentario = comentario;
            DataAvaliacao = DateTime.Now;
        }
    }
}