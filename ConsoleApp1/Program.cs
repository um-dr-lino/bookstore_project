namespace BookVerse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new BookVerseManager();
            var tela = new Tela(80, 25, ConsoleColor.Black, ConsoleColor.White);

            // Criar leitores
            var leitores = MinhasCriacoes.CriarLeitores();
            foreach (var leitor in leitores)
            {
                manager.CadastrarLeitor(leitor.Nome, leitor.Email, leitor.SenhaHash, leitor.DataNascimento);
            }

            // Criar autores
            var autores = MinhasCriacoes.CriarAutores();
            foreach (var autor in autores)
            {
                manager.CadastrarAutor(autor.Nome, autor.Biografia);
            }

            // Criar gêneros
            var generos = MinhasCriacoes.CriarGeneros();
            foreach (var genero in generos)
            {
                manager.CadastrarGenero(genero.Nome);
            }

            // Criar livros
            var livros = MinhasCriacoes.CriarLivros();
            foreach (var livro in livros)
            {
                manager.CadastrarLivro(livro.Titulo, livro.Isbn, livro.AnoPublicacao, livro.AutorId, livro.GeneroId);
            }

            // Criar clubes
            var clubes = MinhasCriacoes.CriarClubes();
            foreach (var clube in clubes)
            {
                manager.CriarClube(clube.Nome, clube.Descricao);
            }

            var opcoesMenu = new List<string>
            {
                // Create
                "1. Cadastrar Leitor",
                "2. Cadastrar Livro",
                "3. Cadastrar Clube de Leitura",
                "4. Criar Encontro",
                // Read
                "5. Listar Leitores",
                "6. Listar Livros",
                "7. Listar Clubes",
                "8. Listar Encontros",
                // Update
                "9. Editar Leitor",
                "10. Editar Livro",
                "11. Editar Clube",
                // Delete
                "12. Excluir Leitor",
                "13. Excluir Livro",
                "14. Excluir Clube",
                "15. Excluir Encontro",

                "0. Sair"
            };

            while (true)
            {
                tela.prepararTela("BookVerse – Clube de Leitura Online");
                string opcao = tela.mostrarMenu(opcoesMenu, 5, 4);

                tela.limparArea(2, 3, 78, 22);

                switch (opcao)
                {
                    case "1": CadastrarLeitorUI(manager, tela); break;
                    case "2": CadastrarLivroUI(manager, tela); break;
                    case "3": CriarClubeUI(manager, tela); break;
                    // case "4": InscreverLeitorEmClubeUI(manager, tela); break;
                    case "4": criarEncontroUI(manager, tela); break;
                    // case "5": RegistrarLeituraUI(manager, tela); break;
                    // case "6": VerRankingLeitoresUI(manager, tela); break;
                    case "5": ListarLeitoresUI(manager, tela); break;
                    case "6": ListarLivros(manager, tela); break;
                    case "7": ListarClubesUI(manager, tela); break;
                    case "8": ListarEncontrosUI(manager, tela); break;
                    case "9": EditarLeitorUI(manager, tela); break;
                    case "10": EditarLivroUI(manager, tela); break;
                    case "11": EditarClubeUI(manager, tela); break;
                    case "12": DeletarLeitor(manager, tela); break;
                    case "13": DeletarLivro(manager, tela); break;
                    case "14": DeletarClube(manager, tela); break;
                    case "15": DeletarEncontro(manager, tela); break;
                    case "0": return;
                    default:
                        tela.centralizar("Opção inválida!");
                        break;
                }

                tela.centralizar("Pressione qualquer tecla para continuar...", 24);
                Console.ReadKey();
            }
        }

        private static void DesenharFormulario(Tela tela, string titulo, int altura, out int col, out int lin)
        {
            col = 20;
            lin = 5;
            int colFim = col + 45;
            int linFim = lin + altura;
            tela.desenharMoldura(col, lin, colFim, linFim);
            tela.centralizar(titulo, lin + 1, col, colFim);
            lin += 3;
        }

        private static void CadastrarLeitorUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Cadastrar Novo Leitor", 7, out int col, out int lin);

            Console.SetCursorPosition(col + 2, lin);
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("Digite sua data de nascimento: ");
            string dataNascimento = Console.ReadLine();

            manager.CadastrarLeitor(nome, email, senha, dataNascimento);

            tela.centralizar("SUCESSO: Leitor cadastrado!", 20);
        }

        private static void CadastrarLivroUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Cadastrar Novo Livro", 9, out int col, out int lin);

            Console.SetCursorPosition(col + 2, lin);
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            int ano = 0;
            bool anoValido = false;
            while (!anoValido)
            {
                Console.SetCursorPosition(col + 2, lin + 2);
                Console.Write("Ano de Publicação: ");
                string inputAno = Console.ReadLine();
                tela.limparArea(col + 2, lin + 3, col + 45, lin + 5);

                if (int.TryParse(inputAno, out ano))
                {
                    anoValido = true;
                }
                else
                {
                    Console.SetCursorPosition(col + 2, lin + 3);
                    Console.WriteLine("Por favor, digite um ano válido (apenas números).");
                    Console.SetCursorPosition(col + 2, lin + 2);
                    Console.Write(new string(' ', inputAno.Length));
                }
            }

            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("Nome do Autor: ");
            string nomeAutor = Console.ReadLine();
            var autor = manager.ObterAutorPorNome(nomeAutor);
            if (autor == null)
            {
                Console.SetCursorPosition(col + 2, lin + 4);
                Console.Write("Biografia do Autor: ");
                string biografia = Console.ReadLine();
                autor = manager.CadastrarAutor(nomeAutor, biografia);
            }

            Console.SetCursorPosition(col + 2, lin + 5);
            Console.Write("Nome do Gênero: ");
            string nomeGenero = Console.ReadLine();
            var genero = manager.ObterGeneroPorNome(nomeGenero);
            if (genero == null)
            {
                genero = manager.CadastrarGenero(nomeGenero);
            }

            manager.CadastrarLivro(titulo, isbn, ano, autor.Id, genero.Id);

            tela.centralizar("SUCESSO: Livro cadastrado!", 20);
        }


        private static void RegistrarLeituraUI(BookVerseManager manager, Tela tela)
        {
            // Conforme o diagrama, uma Leitura (avaliação) conecta um Leitor a um Encontro.
            DesenharFormulario(tela, "Registrar Avaliação de Leitura", 8, out int col, out int lin);

            // É útil mostrar as listas para o usuário saber os IDs
            EditarLeitorUI(manager, tela);
            ListarEncontrosUI(manager, tela);

            Console.SetCursorPosition(col + 2, lin);
            Console.Write("ID do Leitor: ");
            int leitorId = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(col + 2, lin + 4);
            Console.Write("Id do Livro: ");
            int livroId = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(col + 2, lin + 5);
            Console.Write("Id do clube: ");
            int clubeId = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write("Nota (0.0 a 10.0): ");
            float nota = float.Parse(Console.ReadLine());

            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("Comentário: ");
            string comentario = Console.ReadLine();

            manager.RegistrarLeitura(leitorId, livroId, clubeId, nota, comentario);
            tela.centralizar("SUCESSO: Avaliação registrada!", 20);
        }

        private static void ListarLeitoresUI(BookVerseManager manager, Tela tela)
        {
            int col = 5, lin = 4, colFim = 75, linFim = 22;
            tela.desenharMoldura(col, lin, colFim, linFim);
            tela.centralizar("Lista de Leitores e Clubes", lin + 1, col, colFim);

            int linhaAtual = lin + 3;

            // Primeiro listar os leitores
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("=== LEITORES CADASTRADOS ===");
            var leitores = manager.ObterLeitores();
            if (leitores.Any())
            {
                foreach (var leitor in leitores)
                {
                    if (linhaAtual >= linFim - 8) break; // Deixa espaço para os clubes
                    Console.SetCursorPosition(col + 2, linhaAtual++);
                    Console.Write($"ID: {leitor.Id} | Nome: {leitor.Nome}");
                }
            }
            else
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write("Nenhum leitor cadastrado.");
            }

            linhaAtual += 1; // Espaço entre seções

            // Depois listar os clubes
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("=== CLUBES E SEUS MEMBROS ===");
            var clubes = manager.ObterClubes();

            if (!clubes.Any())
            {
                Console.SetCursorPosition(col + 2, linhaAtual);
                Console.Write("Nenhum clube de leitura cadastrado.");
                return;
            }

            foreach (var clube in clubes)
            {
                if (linhaAtual >= linFim - 2) break;

                string nomeModerador = manager.ObterLeitorPorId(clube.ModeradorId)?.Nome ?? "N/A";
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {clube.Id} | Nome: {clube.Nome} | Moderador: {nomeModerador}");

                var membros = manager.ListarMembrosClube(clube.Id);
                if (membros.Any())
                {
                    if (linhaAtual >= linFim - 2) break;
                    Console.SetCursorPosition(col + 4, linhaAtual++);
                    var nomesMembros = string.Join(", ", membros.Select(m => m.Nome).Take(5));
                    Console.Write($"Membros: {nomesMembros}{(membros.Count > 5 ? "..." : "")}");
                }
                else
                {
                    if (linhaAtual >= linFim - 2) break;
                    Console.SetCursorPosition(col + 4, linhaAtual++);
                    Console.Write("Membros: Nenhum membro inscrito.");
                }
                linhaAtual++; // Espaço entre clubes
            }
        }

        private static void CriarClubeUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Criar Novo Clube de Leitura", 7, out int col, out int lin);
            ListarLeitoresUI(manager, tela, false, 15);

            Console.SetCursorPosition(col + 2, lin);
            Console.Write("Nome do Clube: ");
            string nome = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            manager.CriarClube(nome, descricao);
            tela.centralizar("SUCESSO: Clube de leitura criado!", 20);
        }

        private static void InscreverLeitorEmClubeUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Inscrever Leitor em Clube", 6, out int col, out int lin);
            ListarLeitoresUI(manager, tela, false, 12);
            ListarClubesUI(manager, tela);

            Console.SetCursorPosition(col + 2, lin);
            Console.Write("ID do Leitor: ");
            int leitorId = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("ID do Clube: ");
            int clubeId = int.Parse(Console.ReadLine());

            manager.InscreverLeitorEmClube(leitorId, clubeId);
            tela.centralizar("SUCESSO: Inscrição realizada!", 20);
        }

        private static void criarEncontroUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Criar Novo Encontro", 7, out int col, out int lin);
            ListarClubesUI(manager, tela);
            tela.limparArea(2, 3, 78, 22);
            Console.SetCursorPosition(col + 2, lin);
            Console.Write("Tema do Encontro: ");
            string tema = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Data do Encontro (dd/mm/yyyy): ");
            string dataEncontro = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write("Digite o ID do Clube: ");
            int clubeId = int.Parse(Console.ReadLine());

            manager.CriarEncontro(tema, dataEncontro, clubeId);
            tela.centralizar("SUCESSO: Encontro criado!", 20);
        }

        private static void ListarLeitoresUI(BookVerseManager manager, Tela tela, bool desenharMoldura, int linhaInicial = 7)
        {
            int col = 5, linhaAtual = linhaInicial;
            if (desenharMoldura)
            {
                tela.desenharMoldura(col, 4, 75, 22);
                tela.centralizar("LISTA DE LEITORES", 5, col, 75);
            }
            Console.SetCursorPosition(col + 2, linhaAtual - 1);
            Console.Write("--- Leitores Disponíveis ---");
            foreach (var leitor in manager.ObterLeitores().Take(5)) // Limita para não poluir a tela
            {
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {leitor.Id} | Nome: {leitor.Nome}");
            }
        }

        private static void ListarClubesUI(BookVerseManager manager, Tela tela)
        {
            int col = 5, lin = 4, colFim = 75, linFim = 22;
            tela.desenharMoldura(col, lin, colFim, linFim);
            tela.centralizar("Lista de Clubes de Leitura", lin + 1, col, colFim);

            int linhaAtual = lin + 3;

            var clubes = manager.ObterClubes();
            if (!clubes.Any())
            {
                Console.SetCursorPosition(col + 2, linhaAtual);
                Console.Write("Nenhum clube cadastrado.");
                return;
            }

            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("=== CLUBES DE LEITURA ===");
            linhaAtual++;

            foreach (var clube in clubes)
            {
                if (linhaAtual >= linFim - 2) break;

                Console.SetCursorPosition(col + 2, linhaAtual++);
                string nomeModerador = manager.ObterLeitorPorId(clube.ModeradorId)?.Nome ?? "N/A";
                Console.Write($"ID: {clube.Id} | Nome: {clube.Nome} | Moderador: {nomeModerador}");

                var membros = manager.ListarMembrosClube(clube.Id);
                if (membros.Any())
                {
                    Console.SetCursorPosition(col + 4, linhaAtual++);
                    var nomesMembros = string.Join(", ", membros.Select(m => m.Nome).Take(3));
                    Console.Write($"Membros: {nomesMembros}{(membros.Count > 3 ? "..." : "")}");
                }
                else
                {
                    Console.SetCursorPosition(col + 4, linhaAtual++);
                    Console.Write("Sem membros inscritos");
                }
                linhaAtual++; // Espaço entre clubes
            }
        }

    private static void ListarEncontrosUI(BookVerseManager manager, Tela tela)
    {
        int col = 5, lin = 4, colFim = 75, linFim = 22;
        tela.desenharMoldura(col, lin, colFim, linFim);
        tela.centralizar("Lista de Encontros", lin + 1, col, colFim);

        int linhaAtual = lin + 3;

        var encontros = manager.ObterEncontros();
        if (!encontros.Any())
        {
            Console.SetCursorPosition(col + 2, linhaAtual);
            Console.Write("Nenhum encontro cadastrado.");
            return;
        }

        Console.SetCursorPosition(col + 2, linhaAtual++);
        Console.Write("=== ENCONTROS DISPONÍVEIS ===");
        linhaAtual++;

        foreach (var encontro in encontros.Take(5))
        {
            if (linhaAtual >= linFim - 2) break;

            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write($"ID: {encontro.Id} | Tema: {encontro.Tema} | Data: {encontro.Data} | Status: {encontro.Status}");
        }
    }

        private static void ListarLivros(BookVerseManager manager, Tela tela)
        {
            int col = 5, lin = 4, colFim = 75, linFim = 22;
            tela.desenharMoldura(col, lin, colFim, linFim);
            tela.centralizar("Catálogo Geral", lin + 1, col, colFim);

            int linhaAtual = lin + 3;

            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- LIVROS ---");
            foreach (var livro in manager.ObterLivros())
            {
                if (linhaAtual > 12) break;
                Console.SetCursorPosition(col + 2, linhaAtual++);
                string nomeAutor = manager.ObterAutorPorId(livro.AutorId)?.Nome ?? "N/A";
                string nomeGenero = manager.ObterGeneroPorId(livro.GeneroId)?.Nome ?? "N/A";
                Console.Write($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {nomeAutor} | Gênero: {nomeGenero}");
            }

            linhaAtual = 14;
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- AUTORES ---");
            foreach (var autor in manager.ObterAutores())
            {
                if (linhaAtual > 18) break;
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {autor.Id} | Nome: {autor.Nome}");
            }

            linhaAtual = 20;
            Console.SetCursorPosition(col + 2, linhaAtual++);
            Console.Write("--- GÊNEROS ---");
            foreach (var genero in manager.ObterGeneros())
            {
                if (linhaAtual > linFim - 1) break;
                Console.SetCursorPosition(col + 2, linhaAtual++);
                Console.Write($"ID: {genero.Id} | Nome: {genero.Nome}");
            }
        }
        private static void EditarLeitorUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Editar Perfil do Leitor", 15, out int col, out int lin);

            var leitores = manager.ObterLeitores().Take(5).ToList();
            int lastLine = 14 + leitores.Count + 1;

            ListarLeitoresUI(manager, tela, false, 14);

            Console.SetCursorPosition(col + 2, lastLine);
            tela.centralizar("Digite o ID do leitor que você deseja editar: ", 24);
            string input = Console.ReadLine();

            // Validate input
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int idLeitor))
            {
                tela.centralizar("ERRO: ID inválido!", 24);
                return;
            }

            var leitor = manager.ObterLeitorPorId(idLeitor);
            if (leitor == null)
            {
                tela.centralizar("ERRO: Leitor não encontrado!", 24);
                return;
            }

            tela.limparArea(2, 3, 78, 22);
            DesenharFormulario(tela, "Editar Perfil do Leitor", 15, out col, out lin);

            // Rest of your existing code...
            Console.SetCursorPosition(col + 2, lin);
            Console.Write($"Nome atual: {leitor.Nome}");
            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Novo nome (Enter para manter): ");
            string novoNome = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write($"Email atual: {leitor.Email}");
            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("Novo email (Enter para manter): ");
            string novoEmail = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 4);
            Console.Write("Senha atual: ******");
            Console.SetCursorPosition(col + 2, lin + 5);
            Console.Write("Nova senha (Enter para manter): ");
            string novaSenha = Console.ReadLine();

            var resultado = manager.AtualizaLeitor(
                idLeitor,
                string.IsNullOrWhiteSpace(novoNome) ? leitor.Nome : novoNome,
                string.IsNullOrWhiteSpace(novoEmail) ? leitor.Email : novoEmail,
                string.IsNullOrWhiteSpace(novaSenha) ? leitor.SenhaHash : novaSenha
            );

            tela.centralizar("SUCESSO: Dados atualizados com sucesso!", 24);
        }
        private static void EditarLivroUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Editar Livro", 15, out int col, out int lin);

            var livros = manager.ObterLivros().Take(5).ToList();
            int lastLine = 14 + livros.Count + 1;

            ListarLivros(manager, tela);

            Console.SetCursorPosition(col + 2, lastLine);
            tela.centralizar("Digite o ID do livro que você deseja editar: ", 24);
            string input = Console.ReadLine();

            // Validate input
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int idLivro))
            {
                tela.centralizar("ERRO: ID inválido!", 24);
                return;
            }

            var livro = manager.ObterLivroPorId(idLivro);
            if (livro == null)
            {
                tela.centralizar("ERRO: Livro não encontrado!", 24);
                return;
            }

            tela.limparArea(2, 3, 78, 22);
            DesenharFormulario(tela, "Editar Livro", 15, out col, out lin);

            Console.SetCursorPosition(col + 2, lin);
            Console.Write($"Título atual: {livro.Titulo}");
            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Novo título (Enter para manter): ");
            string novoTitulo = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write($"ISBN atual: {livro.Isbn}");
            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("Novo ISBN (Enter para manter): ");
            string novoIsbn = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 4);
            Console.Write($"Ano atual: {livro.AnoPublicacao}");
            Console.SetCursorPosition(col + 2, lin + 5);
            Console.Write("Novo ano (Enter para manter): ");
            string novoAnoStr = Console.ReadLine();

            int novoAno = livro.AnoPublicacao; // Default to current year
            if (!string.IsNullOrWhiteSpace(novoAnoStr))
            {
                if (!int.TryParse(novoAnoStr, out novoAno))
                {
                    tela.centralizar("ERRO: Ano inválido!", 24);
                    return;
                }
            }

            manager.AtualizarLivro(
                idLivro,
                string.IsNullOrWhiteSpace(novoTitulo) ? livro.Titulo : novoTitulo,
                string.IsNullOrWhiteSpace(novoIsbn) ? livro.Isbn : novoIsbn
            );

            tela.centralizar("SUCESSO: Livro atualizado com sucesso!", 24);
        }
        private static void EditarClubeUI(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Editar Clube de Leitura", 15, out int col, out int lin);

            var clubes = manager.ObterClubes().Take(5).ToList();
            int lastLine = 14 + clubes.Count + 1;

            ListarClubesUI(manager, tela);

            Console.SetCursorPosition(col + 2, lastLine);
            tela.centralizar("Digite o ID do clube que você deseja editar: ", 24);
            string input = Console.ReadLine();

            // Validate input
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int idClube))
            {
                tela.centralizar("ERRO: ID inválido!", 24);
                return;
            }

            var clube = manager.ObterClubePorId(idClube);
            if (clube == null)
            {
                tela.centralizar("ERRO: Clube não encontrado!", 24);
                return;
            }

            tela.limparArea(2, 3, 78, 22);
            DesenharFormulario(tela, "Editar Clube de Leitura", 15, out col, out lin);

            Console.SetCursorPosition(col + 2, lin);
            Console.Write($"Nome atual: {clube.Nome}");
            Console.SetCursorPosition(col + 2, lin + 1);
            Console.Write("Novo nome (Enter para manter): ");
            string novoNome = Console.ReadLine();

            Console.SetCursorPosition(col + 2, lin + 2);
            Console.Write($"Descrição atual: {clube.Descricao}");
            Console.SetCursorPosition(col + 2, lin + 3);
            Console.Write("Nova descrição (Enter para manter): ");
            string novaDescricao = Console.ReadLine();

            manager.AtualizarClube(
                idClube,
                string.IsNullOrWhiteSpace(novoNome) ? clube.Nome : novoNome,
                string.IsNullOrWhiteSpace(novaDescricao) ? clube.Descricao : novaDescricao
            );

            tela.centralizar("SUCESSO: Clube atualizado com sucesso!", 24);
        }
        public static void DeletarLeitor(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Excluir Leitor", 7, out int col, out int lin);
            ListarLeitoresUI(manager, tela);

            Console.SetCursorPosition(col + 2, lin);
            tela.centralizar("Digite o ID do leitor que deseja excluir: ",24);
            int idLeitor = int.Parse(Console.ReadLine());

            if (manager.DeletarLeitor(idLeitor))
            {
                tela.centralizar("SUCESSO: Leitor excluído com sucesso!", 20);
            }
            else
            {
                tela.centralizar("ERRO: Leitor não encontrado ou não pode ser excluído!", 20);
            }
        }

        public static void DeletarLivro(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Excluir Livro", 7, out int col, out int lin);
            ListarLivros(manager, tela);

            Console.SetCursorPosition(col + 2, lin);
            tela.centralizar("Digite o ID do livro que deseja excluir: ",24);
            int idLivro = int.Parse(Console.ReadLine());

            if (manager.DeletarLivro(idLivro))
            {
                tela.centralizar("SUCESSO: Livro excluído com sucesso!", 20);
            }
            else
            {
                tela.centralizar("ERRO: Livro não encontrado ou não pode ser excluído!", 20);
            }
        }
        public static void DeletarClube(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Excluir Clube de Leitura", 7, out int col, out int lin);
            ListarClubesUI(manager, tela);

            Console.SetCursorPosition(col + 2, lin);
            tela.centralizar("Digite o ID do clube que deseja excluir: ",24);
            int idClube = int.Parse(Console.ReadLine());

            if (manager.DeletarClube(idClube))
            {
                tela.centralizar("SUCESSO: Clube excluído com sucesso!", 20);
            }
            else
            {
                tela.centralizar("ERRO: Clube não encontrado ou não pode ser excluído!", 20);
            }
        }
        public static void DeletarEncontro(BookVerseManager manager, Tela tela)
        {
            DesenharFormulario(tela, "Excluir Encontro", 7, out int col, out int lin);
            ListarEncontrosUI(manager, tela);

            Console.SetCursorPosition(col + 2, lin);
            tela.centralizar("Digite o ID do encontro que deseja excluir: ",24);
            int idEncontro = int.Parse(Console.ReadLine());

            if (manager.DeletarEncontro(idEncontro))
            {
                tela.centralizar("SUCESSO: Encontro excluído com sucesso!", 20);
            }
            else
            {
                tela.centralizar("ERRO: Encontro não encontrado ou não pode ser excluído!", 20);
            }
        }
    }
}