using EstudoProjetoCS.Data;
using EstudoProjetoCS.Models;

namespace EstudoProjetoCS.Interfaces
{
    public interface ILoginRepository
    {
        public UsuarioModel BuscarLogin(string login);
    }
}
