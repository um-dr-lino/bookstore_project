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
        private List<Participacao> _participacoes = new List<Participacao>();
        private List<Leitura> _leituras = new List<Leitura>();

        private int _proximoIdLeitor = 1;
        private int _proximoIdAutor = 1;
        private int _proximoIdGenero = 1;
        private int _proximoIdLivro = 1;
        private int _proximoIdClube = 1;

        public List<Leitor> ObterLeitores() => _leitores;
        public List<Autor> ObterAutores() => _autores;
        public List<Genero> ObterGeneros() => _generos;
        public List<Livro> ObterLivros() => _livros;
        public List<ClubeLeitura> ObterClubes() => _clubes;

        public void CadastrarLeitor(string nome, string email) => _leitores.Add(new Leitor(_proximoIdLeitor++, nome, email));
        public void CadastrarAutor(string nome) => _autores.Add(new Autor(_proximoIdAutor++, nome));
        public void CadastrarGenero(string nome) => _generos.Add(new Genero(_proximoIdGenero++, nome));
        public string CadastrarLivro(string titulo, int autorId, int generoId)
        {
            if (!_autores.Any(a => a.Id == autorId)) return "ERRO: Autor não encontrado.";
            if (!_generos.Any(g => g.Id == generoId)) return "ERRO: Gênero não encontrado.";
            _livros.Add(new Livro(_proximoIdLivro++, titulo, autorId, generoId));
            return "SUCESSO: Livro cadastrado!";
        }
        
        public string CriarClube(string tema, int moderadorId)
        {
            if (!_leitores.Any(l => l.Id == moderadorId)) return "ERRO: Leitor (moderador) não encontrado.";
            _clubes.Add(new ClubeLeitura(_proximoIdClube++, tema, moderadorId));
            return "SUCESSO: Clube de leitura criado!";
        }

        public string InscreverLeitorEmClube(int leitorId, int clubeId)
        {
            if (!_leitores.Any(l => l.Id == leitorId)) return "ERRO: Leitor não encontrado.";
            if (!_clubes.Any(c => c.Id == clubeId)) return "ERRO: Clube de Leitura não encontrado.";
            if (_participacoes.Any(p => p.LeitorId == leitorId && p.ClubeLeituraId == clubeId)) return "ERRO: Leitor já está inscrito neste clube.";
            
            _participacoes.Add(new Participacao(leitorId, clubeId));
            return "SUCESSO: Inscrição realizada!";
        }
        
        public string RegistrarLeitura(int leitorId, int livroId, int clubeId, double nota)
        {
            if (!_participacoes.Any(p => p.LeitorId == leitorId && p.ClubeLeituraId == clubeId)) return "ERRO: Leitor não participa deste clube.";
            if (!_livros.Any(l => l.Id == livroId)) return "ERRO: Livro não encontrado.";
            
            _leituras.Add(new Leitura(leitorId, livroId, clubeId, nota));
            return "SUCESSO: Leitura e nota registradas!";
        }

        public Dictionary<string, int> ObterRankingLeitores()
        {
            var ranking = _leituras
                .GroupBy(l => l.LeitorId)
                .Select(g => new
                {
                    LeitorId = g.Key,
                    LivrosLidos = g.Count()
                })
                .OrderByDescending(x => x.LivrosLidos)
                .Join(_leitores,
                      rank => rank.LeitorId,
                      leitor => leitor.Id,
                      (rank, leitor) => new { leitor.Nome, rank.LivrosLidos }
                )
                .ToDictionary(item => item.Nome, item => item.LivrosLidos);
            
            return ranking;
        }
    }
}