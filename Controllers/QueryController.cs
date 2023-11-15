using EstudoProjetoCS.Data;
using EstudoProjetoCS.Helper;
using EstudoProjetoCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace EstudoProjetoCS.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto _context;
        private readonly ISessao _sessao;
        public QueryController(Contexto context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }
        public IActionResult ConsultaAgrupamento()
        {
            if (_sessao.BuscarSessao() != null)
            {
                var cidade = from c in _context.Cidades
                             .OrderBy(c => c.Estado)
                             .ToList()
                             group c by new  {c.Estado}
                             into newGrupo
                             select new CidadeModel
                             {
                                 Estado = newGrupo.Key.Estado,
                             };
                return View(cidade);
            }
            return View();
        }
    }
}
