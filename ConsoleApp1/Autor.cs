namespace BookVerse
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Autor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}