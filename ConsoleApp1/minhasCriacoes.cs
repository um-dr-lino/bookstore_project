using System.Collections.Generic;

namespace BookVerse
{
    public static class MinhasCriacoes
    {
        public static List<Leitor> CriarLeitores()
        {
            var leitores = new List<Leitor>();
            leitores.Add(new Leitor("Lino", "lino@email.com", "senha123", "01-01-1990"));
            leitores.Add(new Leitor("Vinicis Gay", "novellu@novellu.com", "senha456", "15-05-1995"));
            return leitores;
        }

        public static List<Autor> CriarAutores()
        {
            var autores = new List<Autor>();
            autores.Add(new Autor(1, "J.R.R. Tolkien", "Autor de O Senhor dos Anéis"));
            autores.Add(new Autor(2, "Machado de Assis", "Autor brasileiro, escritor de Dom Casmurro"));
            autores.Add(new Autor(3, "George Orwell", "Autor de 1984 e A Revolução dos Bichos"));
            return autores;
        }

        public static List<Genero> CriarGeneros()
        {
            var generos = new List<Genero>();
            generos.Add(new Genero(1, "Fantasia"));
            generos.Add(new Genero(2, "Literatura Brasileira"));
            generos.Add(new Genero(3, "Ficção Científica"));
            return generos;
        }

        public static List<Livro> CriarLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro(1, "O Senhor dos Anéis", "978-3-16-148410-0", 1954, 1, 1));
            livros.Add(new Livro(2, "Dom Casmurro", "978-85-359-0277-8", 1899, 2, 2));
            livros.Add(new Livro(3, "1984", "978-0-452-28423-4", 1949, 3, 3));
            return livros;
        }

        public static List<ClubeLeitura> CriarClubes()
        {
            var clubes = new List<ClubeLeitura>();
            clubes.Add(new ClubeLeitura("Clube de Fantasia", "Clube dedicado a livros de fantasia"));
            clubes.Add(new ClubeLeitura("Clube de Clássicos", "Clube de literatura clássica"));
            return clubes;
        }
    }
}