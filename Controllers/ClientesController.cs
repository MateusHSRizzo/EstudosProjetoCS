using EstudoProjetoCS.Models;
using EstudoProjetoCS.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace EstudoProjetoCS.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente) 
        {
            _clienteRepositorio.Adicionar(cliente);

            return RedirectToAction("Index");
        }
    }
}
