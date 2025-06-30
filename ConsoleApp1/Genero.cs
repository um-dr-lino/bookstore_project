namespace BookVerse
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Genero(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}