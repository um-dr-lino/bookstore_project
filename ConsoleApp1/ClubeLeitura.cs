using System;
using System.Collections.Generic;

namespace BookVerse
{
    public class ClubeLeitura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int ModeradorId { get; set; }

        public ClubeLeitura(string nome, string descricao, int moderadorId)
        {
            Nome = nome;
            Descricao = descricao;
            ModeradorId = moderadorId;
            DataCriacao = DateTime.Now;
        }
        
        public ClubeLeitura(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}