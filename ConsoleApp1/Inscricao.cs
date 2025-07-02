using System;

namespace BookVerse
{
    public class Inscricao
    {
        public DateTime DataInscricao { get; set; }
        public string Status { get; set; }
        public int LeitorId { get; set; }
        public int ClubeId { get; set; }

        public Inscricao(int leitorId, int clubeId)
        {
            LeitorId = leitorId;
            ClubeId = clubeId;
            DataInscricao = DateTime.Now;
            Status = "Ativo";
        }
    }
}