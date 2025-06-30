namespace BookVerse
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Leitor(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}