namespace BookVerse
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }

        public Livro(int id, string titulo, int autorId, int generoId)
        {
            Id = id;
            Titulo = titulo;
            AutorId = autorId;
            GeneroId = generoId;
        }
    }
}