using EstudoProjetoCS.Data;
using EstudoProjetoCS.Helper;
using EstudoProjetoCS.Interfaces;
using EstudoProjetoCS.Models;
using EstudoProjetoCS.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EstudoProjetoCS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ISessao _sessao;
        public LoginController(ILoginRepository loginRepository, ISessao sessao)
        {
            _loginRepository = loginRepository;
            _sessao = sessao;
        }
        
        public IActionResult Index()
        {
            if(_sessao.BuscarSessao() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _loginRepository.BuscarLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Password))
                        {
                            _sessao.CriarSessao(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MenssagemErro"] = "Senha incorreta!";
                        return RedirectToAction(nameof(Index));
                    }
                    TempData["MenssagemErro"] = "Usuário incorreto!";
                }
                return View("Index");
            }
            catch (Exception e) 
            {
                throw;
            }
        }
    }
}
