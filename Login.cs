public class Login
{
    private BookVerseManager _manager;

    public Login(BookVerseManager manager)
    {
        _manager = manager;
    }

    public Leitor FazerLogin(string email, string senha)
    {
        var leitor = _manager.ObterLeitores().FirstOrDefault(l => 
            l.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (leitor == null)
        {
            throw new Exception("Email não cadastrado.");
        }

        if (!leitor.SenhaHash.Equals(senha))
        {
            throw new Exception("Senha incorreta.");
        }

        return leitor;
    }
}