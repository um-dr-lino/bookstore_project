namespace BookVerse
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Biografia { get; set; }

        public Autor(int id, string nome, string biografia)
        {
            Id = id;
            Nome = nome;
            Biografia = biografia;
        }
    }
}