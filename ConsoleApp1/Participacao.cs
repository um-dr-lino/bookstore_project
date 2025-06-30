using System;

namespace BookVerse
{
    public class Participacao
    {
        public int LeitorId { get; set; }
        public int ClubeLeituraId { get; set; }
        public DateTime DataInscricao { get; set; }

        public Participacao(int leitorId, int clubeLeituraId)
        {
            LeitorId = leitorId;
            ClubeLeituraId = clubeLeituraId;
            DataInscricao = DateTime.Now;
        }
    }
}