using EstudoProjetoCS.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EstudoProjetoCS.Controllers
{
    public class RestritoController : Controller
    {
        [PagUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
