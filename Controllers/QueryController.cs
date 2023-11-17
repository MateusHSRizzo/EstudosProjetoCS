using EstudoProjetoCS.Data;
using EstudoProjetoCS.Helper;
using EstudoProjetoCS.Models;
using EstudoProjetoCS.Models.Consultas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Xml.Schema;

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
        public IActionResult ConsultaAgrupamentoMes()
        {
            IEnumerable<grpProcedimentosMes> procedimentos =
                from p in _context.Procedimentos
                .Where(w => w.Estado == Enum.ProcedimentoEnum.Concluido)
                .OrderBy(o => o.Data_Solicitacao.Month)
                .ToList()
                group p by new { p.Data_Solicitacao.Month }
                into grupo
                select new grpProcedimentosMes
                {
                    Data_Solicitacao = grupo.Key.Month,
                    Valor = grupo.Sum(s => s.Valor)
                };

            return View(procedimentos);
        }

        public IActionResult ConsultaMultiplasTabelas()
        {
            IEnumerable<grpProcedimentosAno> procedimentos =
                from p in _context.Procedimentos
                .Include(t => t.Tecnico)
                .Where(w => w.Estado == Enum.ProcedimentoEnum.Concluido)
                .OrderBy(o => o.Tecnico.Nome)
                .ToList()
                group p by new { p.Tecnico.Nome, p.Data_Solicitacao.Year }
                into grupo
                select new grpProcedimentosAno
                {
                    Tecnico = grupo.Key.Nome,
                    Data = grupo.Key.Year,
                    Valor = Math.Round(grupo.Sum(s => s.Valor), 2)
                };
            return View(procedimentos);
        }

        public IActionResult ConsultaPivotEstado()
        {

            IEnumerable<grpPivotProcedimentos> procedimentos =
                from p in _context.Procedimentos
                .OrderBy(o => o.Data_Solicitacao.Month)
                .ToList()
                group p by new { p.Estado, p.Data_Solicitacao.Month }
                into grupo
                select new grpPivotProcedimentos
                {
                    Estado = grupo.Key.Estado,
                    Data = grupo.Key.Month,
                    Valor = grupo.Sum(s => s.Valor),
                };

            var PivotTableInsArea = procedimentos.ToList().ToPivotTable(
                                                       pivo => pivo.Estado,
                                                       pivo => pivo.Data,
                                                       pivo => pivo.Any() ? pivo.Sum(x => x.Valor) : 0); ;

            List<PivotProcedimentos> lista = new List<PivotProcedimentos>();
            lista = (from DataRow coluna in PivotTableInsArea.Rows
                     select new PivotProcedimentos()
                     {
                         Mes = Convert.ToInt32(coluna[0]),
                         Estado1 = Convert.ToDouble(coluna[1]),
                         Estado2 = Convert.ToDouble(coluna[2])
                     }).ToList();

            return View(lista);

        }
    }
}
