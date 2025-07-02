using System;
using System.Collections.Generic;
using System.Linq;

namespace BookVerse
{
    public class BookVerseManager
    {
        private List<Leitor> _leitores = new List<Leitor>();
        private List<Autor> _autores = new List<Autor>();
        private List<Genero> _generos = new List<Genero>();
        private List<Livro> _livros = new List<Livro>();
        private List<ClubeLeitura> _clubes = new List<ClubeLeitura>();
        private List<Inscricao> _inscricoes = new List<Inscricao>();
        private List<Leitura> _leituras = new List<Leitura>();
        private List<Encontro> _encontros = new List<Encontro>();

        private int _proximoIdLeitor = 1;
        private int _proximoIdAutor = 1;
        private int _proximoIdGenero = 1;
        private int _proximoIdLivro = 1;
        private int _proximoIdClube = 1;
        private int _proximoIdLeitura = 1;
        private int _proximoIdEncontro = 1;

        // Métodos para obter listas
        public List<Leitor> ObterLeitores() => _leitores;
        public List<Autor> ObterAutores() => _autores;
        public List<Genero> ObterGeneros() => _generos;
        public List<Livro> ObterLivros() => _livros;
        public List<ClubeLeitura> ObterClubes() => _clubes;
        public List<Inscricao> ObterInscricoes() => _inscricoes;
        public List<Leitura> ObterLeituras() => _leituras;
        public List<Encontro> ObterEncontros() => _encontros;

        // Cadastro de Leitor
        public void CadastrarLeitor(string nome, string email, string senhaHash, string dataNascimento)
        {
            var leitor = new Leitor(nome, email, senhaHash, dataNascimento);
            leitor.Id = _proximoIdLeitor++;
            _leitores.Add(leitor);
        }

        // Cadastro de Autor
        public Autor CadastrarAutor(string nome, string biografia)
        {
            var autor = new Autor(_proximoIdAutor++, nome, biografia);
            _autores.Add(autor);
            return autor;
        }

        // Cadastro de Gênero
        public Genero CadastrarGenero(string nome)
        {
            var genero = new Genero(_proximoIdGenero++, nome);
            _generos.Add(genero);
            return genero;
        }
        // Cadastro de Livro
        public string CadastrarLivro(string titulo, string isbn, int anoPublicacao, int autorId, int generoId)
        {
            if (!_autores.Any(a => a.Id == autorId)) return "ERRO: Autor não encontrado.";
            if (!_generos.Any(g => g.Id == generoId)) return "ERRO: Gênero não encontrado.";

            var livro = new Livro(_proximoIdLivro++, titulo, isbn, anoPublicacao, autorId, generoId);
            _livros.Add(livro);
            return "SUCESSO: Livro cadastrado!";
        }

        // Criação de Clube de Leitura
        public string CriarClube(string nome, string descricao)
        {
            var clube = new ClubeLeitura(nome, descricao);
            clube.Id = _proximoIdClube++;
            _clubes.Add(clube);
            return "SUCESSO: Clube de leitura criado!";
        }

        // Inscrição de Leitor em Clube
        public string InscreverLeitorEmClube(int leitorId, int clubeId)
        {
            if (!_leitores.Any(l => l.Id == leitorId)) return "ERRO: Leitor não encontrado.";
            if (!_clubes.Any(c => c.Id == clubeId)) return "ERRO: Clube de Leitura não encontrado.";
            if (_inscricoes.Any(i => i.LeitorId == leitorId && i.ClubeId == clubeId))
                return "ERRO: Leitor já está inscrito neste clube.";

            _inscricoes.Add(new Inscricao(leitorId, clubeId));
            return "SUCESSO: Inscrição realizada!";
        }

        // Registro de Leitura
        public string RegistrarLeitura(int leitorId, int livroId, int clubeId, float nota, string comentario)
        {
            if (!_inscricoes.Any(i => i.LeitorId == leitorId && i.ClubeId == clubeId))
                return "ERRO: Leitor não participa deste clube.";
            if (!_livros.Any(l => l.Id == livroId)) return "ERRO: Livro não encontrado.";

            var leitura = new Leitura(leitorId, livroId, clubeId, nota, comentario);
            leitura.Id = _proximoIdLeitura++;
            _leituras.Add(leitura);
            return "SUCESSO: Leitura e nota registradas!";
        }

        // Agendamento de Encontro
        public string AgendarEncontro(string tema, string data, string linkSalaVirtual, int clubeId)
        {
            if (!_clubes.Any(c => c.Id == clubeId)) return "ERRO: Clube não encontrado.";

            var encontro = new Encontro(tema, data, clubeId);
            encontro.Id = _proximoIdEncontro++;
            _encontros.Add(encontro);
            return "SUCESSO: Encontro agendado!";
        }

        // Cancelar Encontro
        public string CancelarEncontro(int encontroId)
        {
            var encontro = _encontros.FirstOrDefault(e => e.Id == encontroId);
            if (encontro == null) return "ERRO: Encontro não encontrado.";

            encontro.Status = "Cancelado";
            return "SUCESSO: Encontro cancelado!";
        }

        public string CriarEncontro(string tema, string data, int clubeId)
        {
            if (!_clubes.Any(c => c.Id == clubeId))
            {
                return "ERRO: Clube de leitura não encontrado.";
            }

            var encontro = new Encontro(tema, data, clubeId);
            encontro.Id = _proximoIdEncontro++;
            _encontros.Add(encontro);
            return "SUCESSO: Encontro agendado!";
        }
        public Autor ObterAutorPorNome(string nome)
        {
            return _autores.FirstOrDefault(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
        public Genero ObterGeneroPorNome(string nome)
        {
            return _generos.FirstOrDefault(g => g.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
        
        public Leitor ObterLeitorPorId(int id)
        {
            return _leitores.FirstOrDefault(l => l.Id == id);
        }

        public Autor ObterAutorPorId(int id)
        {
            return _autores.FirstOrDefault(l => l.Id == id);
        }

        public Genero ObterGeneroPorId(int id)
        {
            return _generos.FirstOrDefault(l => id == id);
        }

        public Livro ObterLivroPorId(int id)
        {
            return _livros.FirstOrDefault(l => l.Id == id);
        }
        public ClubeLeitura ObterClubePorId(int id)
        {
            return _clubes.FirstOrDefault(c => c.Id == id);
        }


        public List<Leitor> ListarMembrosClube(int clubeId)
        {
            if (!_clubes.Any(c => c.Id == clubeId))
            {
                return new List<Leitor>();
            }

            return _inscricoes
                .Where(i => i.ClubeId == clubeId)
                .Join(
                    _leitores,
                    i => i.LeitorId,
                    l => l.Id,
                    (i, l) => l
                )
                .ToList();
        }

        public string AtualizaLeitor(int id, string nome, string email, string senha)
        {
            var leitor = _leitores.FirstOrDefault(l => l.Id == id);
            if (leitor == null)
            {
                return "ERRO: Leitor não encontrado.";
            }

            leitor.UpdateInformacoes(nome, email, senha);
            return "SUCESSO: Leitor atualizado!";
        }

        public string AtualizarLivro(int id, string titulo, string isbn)
        {
            var livro = _livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
            {
                return "ERRO: Livro não encontrado.";
            }

            livro.Titulo = titulo;
            livro.Isbn = isbn;

            return "SUCESSO: Livro atualizado!";
        }
        public string AtualizarClube(int id, string nome, string descricao)
        {
            var clube = _clubes.FirstOrDefault(c => c.Id == id);
            if (clube == null)
            {
                return "ERRO: Clube não encontrado.";
            }

            clube.Nome = nome;
            clube.Descricao = descricao;

            return "SUCESSO: Clube atualizado!";
        }
        public bool DeletarLeitor(int idLeitor)
        {
            var leitor = _leitores.FirstOrDefault(l => l.Id == idLeitor);
            if (leitor == null)
            {
                return false;
            }


            if (_inscricoes.Any(i => i.LeitorId == idLeitor))
            {
                return false;
            }

            if (_clubes.Any(c => c.ModeradorId == idLeitor))
            {
                return false;
            }

            if (_leituras.Any(l => l.LeitorId == idLeitor))
            {
                return false;
            }

            _leitores.Remove(leitor);
            return true;
        }

        public bool DeletarLivro(int idLivro)
        {
            var livro = _livros.FirstOrDefault(l => l.Id == idLivro);
            if (livro == null)
            {
                return false;
            }

            if (_leituras.Any(l => l.LivroId == idLivro))
            {
                return false;
            }

            _livros.Remove(livro);
            return true;
        }
        public bool DeletarClube(int idClube)
        {
            var clube = _clubes.FirstOrDefault(c => c.Id == idClube);
            if (clube == null)
            {
                return false;
            }

            if (_inscricoes.Any(i => i.ClubeId == idClube))
            {
                return false;
            }

            if (_encontros.Any(e => e.ClubeId == idClube))
            {
                return false;
            }

            _clubes.Remove(clube);
            return true;
        }
        public bool DeletarEncontro(int idEncontro)
        {
            var encontro = _encontros.FirstOrDefault(e => e.Id == idEncontro);
            if (encontro == null)
            {
                return false;
            }

            if (encontro.Status != "Agendado")
            {
                return false; 
            }

            _encontros.Remove(encontro);
            return true;
        }
    }
}