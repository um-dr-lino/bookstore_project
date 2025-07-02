using System;

namespace BookVerse
{
    public class Leitor
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string DataNascimento { get; set; }

        public Leitor(string nome, string email, string senhaHash, string dataNascimento)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            DataNascimento = dataNascimento;
        }

        public void UpdateInformacoes(string nome, string email, string senha)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                Nome = nome;
            }
            if (!string.IsNullOrEmpty(email))
            {
                Email = email;
            }
            if (!string.IsNullOrEmpty(senha))
            {
                SenhaHash = senha; 
            }
        }
    }
}