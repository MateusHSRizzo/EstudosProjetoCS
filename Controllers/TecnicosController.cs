﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstudoProjetoCS.Data;
using EstudoProjetoCS.Models;

namespace EstudoProjetoCS.Controllers
{
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
            var contexto = _context.Tecnicos.Include(t => t.Procedimento);
            return View(await contexto.ToListAsync());
        }

        // GET: Tecnicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnicoModel = await _context.Tecnicos
                .Include(t => t.Procedimento)
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
            ViewData["IdProcedimento"] = new SelectList(_context.Procedimentos, "Id", "Descricao");
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Registro,IdProcedimento")] TecnicoModel tecnicoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnicoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProcedimento"] = new SelectList(_context.Procedimentos, "Id", "Descricao", tecnicoModel.IdProcedimento);
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
            ViewData["IdProcedimento"] = new SelectList(_context.Procedimentos, "Id", "Descricao", tecnicoModel.IdProcedimento);
            return View(tecnicoModel);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Registro,IdProcedimento")] TecnicoModel tecnicoModel)
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicoModelExists(tecnicoModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProcedimento"] = new SelectList(_context.Procedimentos, "Id", "Descricao", tecnicoModel.IdProcedimento);
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
                .Include(t => t.Procedimento)
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
                return Problem("Entity set 'Contexto.Tecnicos'  is null.");
            }
            var tecnicoModel = await _context.Tecnicos.FindAsync(id);
            if (tecnicoModel != null)
            {
                _context.Tecnicos.Remove(tecnicoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoModelExists(int id)
        {
          return _context.Tecnicos.Any(e => e.Id == id);
        }
    }
}
