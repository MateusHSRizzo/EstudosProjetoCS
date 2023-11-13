using EstudoProjetoCS.Data;
using EstudoProjetoCS.Interfaces;
using EstudoProjetoCS.Models;

namespace EstudoProjetoCS.Repositorio
{
    public class LoginRepository : ILoginRepository
    {
        private readonly Contexto _contexto;
        public LoginRepository(Contexto contexto)
        {
            _contexto = contexto;
        }
        public UsuarioModel BuscarLogin(string login)
        {
            return _contexto.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
        }
    }
}
