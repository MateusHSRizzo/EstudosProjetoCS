using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstudoProjetoCS.Data;
using EstudoProjetoCS.Models;
using EstudoProjetoCS.Filters;

namespace EstudoProjetoCS.Controllers
{
    [PagUsuarioLogado]
    public class ProcedimentosController : Controller
    {
        private readonly Contexto _context;

        public ProcedimentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Procedimentos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Procedimentos.Include(p => p.Atendente).Include(p => p.Cliente).Include(p => p.Tecnico);
            return View(await contexto.ToListAsync());
        }

        // GET: Procedimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procedimentos == null)
            {
                return NotFound();
            }

            var procedimentoModel = await _context.Procedimentos
                .Include(p => p.Atendente)
                .Include(p => p.Cliente)
                .Include(p => p.Tecnico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentoModel == null)
            {
                return NotFound();
            }

            return View(procedimentoModel);
        }

        // GET: Procedimentos/Create
        [PagUsuarioAdmAtt]
        public IActionResult Create()
        {
            ViewData["IdAtendente"] = new SelectList(_context.Atendentes, "Id", "Nome");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nome");
            return View();
        }

        // POST: Procedimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [PagUsuarioAdmAtt]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo_Procedimento,Descricao,Prioridade,Valor,Data_Solicitacao,IdAtendente,IdCliente,IdTecnico")] ProcedimentoModel procedimentoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(procedimentoModel);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = "Registro criado com seucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                TempData["MenssagemErro"] = $"Registro falhou! {e.Message}";
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAtendente"] = new SelectList(_context.Atendentes, "Id", "Nome", procedimentoModel.IdAtendente);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nome", procedimentoModel.IdCliente);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nome", procedimentoModel.IdTecnico);
            return View(procedimentoModel);
        }

        // GET: Procedimentos/Edit/5
        [PagUsuarioAdmAtt]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procedimentos == null)
            {
                return NotFound();
            }

            var procedimentoModel = await _context.Procedimentos.FindAsync(id);
            if (procedimentoModel == null)
            {
                return NotFound();
            }
            ViewData["IdAtendente"] = new SelectList(_context.Atendentes, "Id", "Nome", procedimentoModel.IdAtendente);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nome", procedimentoModel.IdCliente);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nome", procedimentoModel.IdTecnico);
            return View(procedimentoModel);
        }

        // POST: Procedimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [PagUsuarioAdmAtt]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo_Procedimento,Descricao,Prioridade,Valor,Data_Solicitacao,IdAtendente,IdCliente,IdTecnico")] ProcedimentoModel procedimentoModel)
        {
            if (id != procedimentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimentoModel);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = "Atualização realizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!ProcedimentoModelExists(procedimentoModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["MenssagemErro"] = $"Atualização falhou! {e.Message}";
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["IdAtendente"] = new SelectList(_context.Atendentes, "Id", "Nome", procedimentoModel.IdAtendente);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Nome", procedimentoModel.IdCliente);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "Id", "Nome", procedimentoModel.IdTecnico);
            return View(procedimentoModel);
        }

        // GET: Procedimentos/Delete/5
        [PagUsuarioAdmin]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procedimentos == null)
            {
                return NotFound();
            }

            var procedimentoModel = await _context.Procedimentos
                .Include(p => p.Atendente)
                .Include(p => p.Cliente)
                .Include(p => p.Tecnico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentoModel == null)
            {
                return NotFound();
            }

            return View(procedimentoModel);
        }

        // POST: Procedimentos/Delete/5
        [PagUsuarioAdmin]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procedimentos == null)
            {
                return Problem("Entidade não existe");
            }
            var procedimentoModel = await _context.Procedimentos.FindAsync(id);
            if (procedimentoModel != null)
            {
                _context.Procedimentos.Remove(procedimentoModel);
            }
            
            await _context.SaveChangesAsync();
            TempData["MenssagemSucesso"] = "Registro deletado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoModelExists(int id)
        {
          return _context.Procedimentos.Any(e => e.Id == id);
        }
    }
}
