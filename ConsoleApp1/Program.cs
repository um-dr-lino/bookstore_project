using System;
using System.Collections.Generic;

namespace BookVerse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new BookVerseManager();
            var tela = new Tela(80, 25, ConsoleColor.Black, ConsoleColor.White);

            var opcoesMenu = new List<string>
            {
                "1. Cadastrar Leitor",
                "2. Cadastrar Livro",
                "3. Criar Clube de Leitura",
                "4. Inscrever Leitor em Clube",
                "5. Registrar Leitura com Nota",
                "6. Ver Ranking de Leitores",
                "7. Listar Livros, Autores e Gêneros",
                "8. Listar Clubes e Leitores",
                "0. Sair"
            };

            while (true)
            {
                tela.prepararTela("BookVerse – Clube de Leitura Online");
                string opcao = tela.mostrarMenu(opcoesMenu, 5, 4);

                tela.limparArea(2, 3, 78, 22);

                try
                {
                    switch (opcao)
                    {
                        case "1": CadastrarLeitorUI(manager, tela); break;
                        case "2": CadastrarLivroUI(manager, tela); break;
                        case "3": InscreverLeitorEmClubeUI(manager, tela); break;
                        case "4": RegistrarLeituraUI(manager, tela); break;
                        case "5": ListarLivrosAutoresGenerosUI(manager, tela); break;
                        case "6": ListarClubesLeitoresUI(manager, tela); break;
                        case "0": return;
                        default:
                            tela.centralizar("Opção inválida!");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    tela.centralizar($"ERRO DE ENTRADA: {ex.Message}. Por favor, digite um número válido.");
                }
                catch (Exception ex)
                {
                    tela.centralizar($"ERRO INESPERADO: {ex.Message}");
                }

                tela.centralizar("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void DesenharFormulario(Tela tela, string titulo, out int col, out int lin)
        {
            col = 20;
            lin = 5;
            int colFim = col + 45;
            int linFim = lin + 8;
            tela.desenharMoldura(col, lin, colFim, linFim);
            tela.centralizar(titulo, lin + 1, col, colFim);
            lin += 2;
        }
        
        private static void CadastrarLeitorUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Cadastrar Novo Leitor", out int col, out int lin);
            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Nome do Leitor: ");
            string nome = Console.ReadLine();
            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write("Email do Leitor: ");
            string email = Console.ReadLine();
            manager.CadastrarLeitor(nome, email);
            tela.centralizar("SUCESSO: Leitor cadastrado!");
        }
        
        private static void CadastrarLivroUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Cadastrar Novo Livro", out int col, out int lin);

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Título do Livro: ");
            string titulo = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write("Nome do Autor: ");
            string nomeAutor = Console.ReadLine();
            var autor = manager.ObterAutores().FirstOrDefault(a => a.Nome.Equals(nomeAutor, StringComparison.OrdinalIgnoreCase));
            if (autor == null) {
                manager.CadastrarAutor(nomeAutor);
                autor = manager.ObterAutores().Last();
            }

            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("Gênero do Livro: ");
            string nomeGenero = Console.ReadLine();
            var genero = manager.ObterGeneros().FirstOrDefault(g => g.Nome.Equals(nomeGenero, StringComparison.OrdinalIgnoreCase));
            if (genero == null) {
                manager.CadastrarGenero(nomeGenero);
                genero = manager.ObterGeneros().Last();
            }

            string msg = manager.CadastrarLivro(titulo, autor.Id, genero.Id);
            tela.centralizar(msg);
        }

        private static void InscreverLeitorEmClubeUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Inscrever Leitor em Clube", out int col, out int lin);
            ListarLeitoresUI(manager, tela, false);
            ListarClubesUI(manager, tela, false);

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("ID do Leitor: ");
            int leitorId = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write("ID do Clube: ");
            int clubeId = int.Parse(Console.ReadLine());
            
            string msg = manager.InscreverLeitorEmClube(leitorId, clubeId);
            tela.centralizar(msg);
        }

        private static void RegistrarLeituraUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Registrar Leitura e Nota", out int col, out int lin);
            ListarLeitoresUI(manager, tela, false);
            ListarClubesUI(manager, tela, false);
            ListarLivrosUI(manager, tela, false);

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("ID do Leitor: ");
            int leitorId = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write("ID do Clube: ");
            int clubeId = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("ID do Livro: ");
            int livroId = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(col + 2, lin + 4);
            Console.Write("Nota (0 a 10): ");
            double nota = double.Parse(Console.ReadLine());

            string msg = manager.RegistrarLeitura(leitorId, livroId, clubeId, nota);
            tela.centralizar(msg);
        }

        private static void ListarLivrosUI(BookVerseManager manager, Tela tela, bool desenharMoldura)
        {
            int col = 5, linhaAtual = 10;
            if (desenharMoldura)
            {
                int colFim = 75, linFim = 22;
                tela.desenharMoldura(col, 4, colFim, linFim);
                tela.centralizar("LISTA DE LIVROS", 5, col, colFim);
                linhaAtual = 7;
            }

            var autores = manager.ObterAutores();
            var generos = manager.ObterGeneros();
            foreach(var livro in manager.ObterLivros())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                string nomeAutor = autores.FirstOrDefault(a => a.Id == livro.AutorId)?.Nome ?? "Desconhecido";
                string nomeGenero = generos.FirstOrDefault(g => g.Id == livro.GeneroId)?.Nome ?? "Desconhecido";
                Console.Write($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {nomeAutor} | Gênero: {nomeGenero}");
            }
        }
        
        private static void ListarLivrosAutoresGenerosUI(BookVerseManager manager, Tela tela)
        {
            int col = 5, lin = 4, colFim = 75, linFim = 22;
            tela.desenharMoldura(col, lin, colFim, linFim);

            int linhaAtual = lin + 2;
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- GÊNEROS ---");
            foreach (var genero in manager.ObterGeneros())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {genero.Id} | Nome: {genero.Nome}");
            }

            linhaAtual++;
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- AUTORES ---");
            foreach (var autor in manager.ObterAutores())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {autor.Id} | Nome: {autor.Nome}");
            }

            linhaAtual++;
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- LIVROS ---");
            foreach(var livro in manager.ObterLivros())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {livro.Id} | Título: {livro.Titulo} | Autor ID: {livro.AutorId} | Gênero ID: {livro.GeneroId}");
            }
        }

        private static void ListarLeitoresUI(BookVerseManager manager, Tela tela, bool desenharMoldura)
        {
            int col = 5, linhaAtual = 10;
             if (desenharMoldura)
            {
                int colFim = 75, linFim = 22;
                tela.desenharMoldura(col, 4, colFim, linFim);
                tela.centralizar("LISTA DE LEITORES", 5, col, colFim);
                linhaAtual = 7;
            }

            foreach (var leitor in manager.ObterLeitores())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {leitor.Id} | Nome: {leitor.Nome} | Email: {leitor.Email}");
            }
        }

        private static void ListarClubesUI(BookVerseManager manager, Tela tela, bool desenharMoldura)
        {
            int col = 40, linhaAtual = 10;
             if (desenharMoldura)
            {
                int colFim = 75, linFim = 22;
                tela.desenharMoldura(5, 4, colFim, linFim);
                tela.centralizar("LISTA DE CLUBES", 5, 5, colFim);
                linhaAtual = 7;
            }

            var leitores = manager.ObterLeitores();
            foreach (var clube in manager.ObterClubes())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                string nomeModerador = leitores.FirstOrDefault(l => l.Id == clube.ModeradorId)?.Nome ?? "Desconhecido";
                Console.Write($"ID: {clube.Id} | Tema: {clube.Tema} | Moderador: {nomeModerador}");
            }
        }
        
        private static void ListarClubesLeitoresUI(BookVerseManager manager, Tela tela)
        {
            int col = 5, lin = 4, colFim = 75, linFim = 22;
            tela.desenharMoldura(col, lin, colFim, linFim);

            int linhaAtual = lin + 2;
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- LEITORES ---");
            foreach (var leitor in manager.ObterLeitores())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {leitor.Id} | Nome: {leitor.Nome}");
            }

            linhaAtual++;
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- CLUBES DE LEITURA ---");
            var leitores = manager.ObterLeitores();
            foreach (var clube in manager.ObterClubes())
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                string nomeModerador = leitores.FirstOrDefault(l => l.Id == clube.ModeradorId)?.Nome ?? "Desconhecido";
                Console.Write($"ID: {clube.Id} | Tema: {clube.Tema} | Moderador: {nomeModerador}");
            }
        }
    }
}