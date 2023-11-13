using EstudoProjetoCS.Models;

namespace EstudoProjetoCS.Helper
{
    public interface ISessao
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
