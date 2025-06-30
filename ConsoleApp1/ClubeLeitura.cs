namespace BookVerse
{
    public class ClubeLeitura
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public int ModeradorId { get; set; } 

        public ClubeLeitura(int id, string tema, int moderadorId)
        {
            Id = id;
            Tema = tema;
            ModeradorId = moderadorId;
        }
    }
}