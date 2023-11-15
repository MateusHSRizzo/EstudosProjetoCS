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
    [PagUsuarioAdmin]
    public class TecnicosController : Controller
    {
        private readonly Contexto _context;

        public TecnicosController(Contexto context)
        {
            _context = context;
        }

        // GET: Tecnicos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tecnicos.ToListAsync());
        }

        // GET: Tecnicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnicoModel = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicoModel == null)
            {
                return NotFound();
            }

            return View(tecnicoModel);
        }

        // GET: Tecnicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Registro")] TecnicoModel tecnicoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tecnicoModel);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = "Registro realizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                TempData["MenssagemErro"] = $"Registro falhou! {e.Message}";
                return RedirectToAction(nameof(Index));
            }
            return View(tecnicoModel);
        }

        // GET: Tecnicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnicoModel = await _context.Tecnicos.FindAsync(id);
            if (tecnicoModel == null)
            {
                return NotFound();
            }
            return View(tecnicoModel);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Registro")] TecnicoModel tecnicoModel)
        {
            if (id != tecnicoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicoModel);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = $"Atualização realizada com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!TecnicoModelExists(tecnicoModel.Id))
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
            return View(tecnicoModel);
        }

        // GET: Tecnicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnicoModel = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicoModel == null)
            {
                return NotFound();
            }

            return View(tecnicoModel);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tecnicos == null)
            {
                return Problem("Entidade não existe!");
            }
            var tecnicoModel = await _context.Tecnicos.FindAsync(id);
            if (tecnicoModel != null)
            {
                _context.Tecnicos.Remove(tecnicoModel);
            }
            
            await _context.SaveChangesAsync();
            TempData["MenssagemErro"] = $"Registro deletado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoModelExists(int id)
        {
          return _context.Tecnicos.Any(e => e.Id == id);
        }
    }
}
