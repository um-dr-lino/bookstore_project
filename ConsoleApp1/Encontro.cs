using System;

namespace BookVerse
{
    public class Encontro
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        public string LinkSalaVirtual { get; set; }
        public int ClubeId { get; set; }

        public Encontro(string tema, string data,  int clubeId)
        {
            Tema = tema;
            Data = data;
            ClubeId = clubeId;
            Status = "Agendado";
        }
    }
}