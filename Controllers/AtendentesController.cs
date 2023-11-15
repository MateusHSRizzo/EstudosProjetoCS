﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstudoProjetoCS.Data;
using EstudoProjetoCS.Models;
using EstudoProjetoCS.Filters;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;

namespace EstudoProjetoCS.Controllers
{
    [PagUsuarioAdmin]
    public class AtendentesController : Controller
    {
        private readonly Contexto _context;

        public AtendentesController(Contexto context)
        {
            _context = context;
        }

        // GET: Atendentes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Atendentes.ToListAsync());
        }

        // GET: Atendentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atendentes == null)
            {
                return NotFound();
            }

            var atendenteModel = await _context.Atendentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendenteModel == null)
            {
                return NotFound();
            }

            return View(atendenteModel);
        }

        // GET: Atendentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atendentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Registro")] AtendenteModel atendenteModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(atendenteModel);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = "Registro realizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                TempData["MenssagemErro"] = $"Atulização falhou! {e.Message}";
                return RedirectToAction(nameof(Index));
            }
            return View(atendenteModel);
        }

        // GET: Atendentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atendentes == null)
            {
                return NotFound();
            }

            var atendenteModel = await _context.Atendentes.FindAsync(id);
            if (atendenteModel == null)
            {
                return NotFound();
            }
            return View(atendenteModel);
        }

        // POST: Atendentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Registro")] AtendenteModel atendenteModel)
        {
            if (id != atendenteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendenteModel);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = "Atualização realizada com sucesso!";
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!AtendenteModelExists(atendenteModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["MenssagemErro"] = $"Atulização falhou! {e.Message}";
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(atendenteModel);
        }

        // GET: Atendentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atendentes == null)
            {
                return NotFound();
            }

            var atendenteModel = await _context.Atendentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendenteModel == null)
            {
                return NotFound();
            }

            return View(atendenteModel);
        }

        // POST: Atendentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atendentes == null)
            {
                return Problem("Entidade não existe!");
            }
            var atendenteModel = await _context.Atendentes.FindAsync(id);
            if (atendenteModel != null)
            {
                _context.Atendentes.Remove(atendenteModel);
            }

            await _context.SaveChangesAsync();
            TempData["MenssagemSucesso"] = "Registro deletado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool AtendenteModelExists(int id)
        {
            return _context.Atendentes.Any(e => e.Id == id);
        }
    }
}
