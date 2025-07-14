using System.Collections.Generic;

namespace BookVerse
{
    public static class MinhasCriacoes
    {
        public static List<Leitor> CriarLeitores()
        {
            var leitores = new List<Leitor>();
            leitores.Add(new Leitor("Lino", "lino@email.com", "senha123", "01-01-1990"));
            leitores.Add(new Leitor("Vinicis Fernando", "novellu@novellu.com", "senha456", "15-05-1995"));
            leitores.Add(new Leitor("Paulo Manseira", "professordePOO@catolica.com", "senha456", "15-05-1500"));
            return leitores;
        }

        public static List<Autor> CriarAutores()
        {
            var autores = new List<Autor>();
            autores.Add(new Autor(1, "Paulo Manseira", "Autor brasileiro, escritor de os Ensinamentos do manseirismo"));
            autores.Add(new Autor(2, "Machado de Assis", "Autor brasileiro, escritor de Dom Casmurro"));
            autores.Add(new Autor(3, "George Orwell", "Autor de 1984 e A Revolução dos Bichos"));
            autores.Add(new Autor(4, "J.R.R. Tolkien", "Autor de O Senhor dos Anéis"));
            return autores;
        }

        public static List<Genero> CriarGeneros()
        {
            var generos = new List<Genero>();
            generos.Add(new Genero(1, "Passar nas materias"));
            generos.Add(new Genero(2, "Literatura Brasileira"));
            generos.Add(new Genero(3, "Ficção Científica"));
            generos.Add(new Genero(4, "Fantasia"));
            return generos;
        }

        public static List<Livro> CriarLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro(1, "Manseirismo", "222-2-22-22222-2", 2020, 1, 1));
            livros.Add(new Livro(2, "Dom Casmurro", "978-85-359-0277-8", 1899, 2, 2));
            livros.Add(new Livro(3, "1984", "978-0-452-28423-4", 1949, 3, 3));
            livros.Add(new Livro(4, "O Senhor dos Anéis", "978-3-16-148410-0", 1954, 4, 4));
            livros.Add(new Livro(5, "Harry Potter e a Pedra Filosofal", "978-8532530783", 1997, 4, 4));
            livros.Add(new Livro(6, "Memórias Póstumas de Brás Cubas", "978-8535910663", 1881, 2, 2));
            livros.Add(new Livro(7, "A Revolução dos Bichos", "978-8535909555", 1945, 3, 3));
            livros.Add(new Livro(8, "O Hobbit", "978-8578277710", 1937, 4, 4));
            livros.Add(new Livro(9, "Quincas Borba", "978-8535911162", 1891, 2, 2));
            livros.Add(new Livro(10, "O Silmarillion", "978-8578277925", 1977, 4, 4));
            livros.Add(new Livro(11, "Helena", "978-8535911179", 1876, 2, 2));
            livros.Add(new Livro(12, "As Duas Torres", "978-8533613409", 1954, 4, 4));
            livros.Add(new Livro(13, "O Alienista", "978-8535911186", 1882, 2, 2));
            livros.Add(new Livro(14, "O Retorno do Rei", "978-8533613416", 1955, 4, 4));

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