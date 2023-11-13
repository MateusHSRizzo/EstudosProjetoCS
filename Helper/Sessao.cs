using EstudoProjetoCS.Models;
using Newtonsoft.Json;
using System.Drawing;

namespace EstudoProjetoCS.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public UsuarioModel BuscarSessao()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _contextAccessor.HttpContext.Session.SetString("UsuarioLogado", valor);
        }

        public void RemoverSessao()
        {
            _contextAccessor.HttpContext.Session.Remove("UsuarioLogado");
        }
    }
}
