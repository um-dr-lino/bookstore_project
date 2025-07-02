namespace BookVerse
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }

        public Livro(int id, string titulo, string isbn, int anoPublicacao, int autorId, int generoId)
        {
            Id = id;
            Titulo = titulo;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
            AutorId = autorId;
            GeneroId = generoId;
        }

        public Livro(int id, string titulo, string isbn)
        {
            Id = id;
            Titulo = titulo;
            Isbn = isbn;
        }
    }
}