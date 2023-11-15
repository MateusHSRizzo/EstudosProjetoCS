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
    public class UsuariosController : Controller
    {
        private readonly Contexto _context;

        public UsuariosController(Contexto context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Perfil,Login,Password")] UsuarioModel usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(usuarioModel);
                    await MovimentoCadastro(usuarioModel.Login);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = "Registro realizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                TempData["MenssagemErro"] = $"Registro falhou! {e.Message}";
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }
        public async Task<IActionResult> MovimentoCadastro(string login)
        {
            if (ModelState.IsValid)
            {
                MovimentacaoUsuario movimentacaoUsuario = new MovimentacaoUsuario();
                movimentacaoUsuario.DataCadastro = DateTime.Now;
                movimentacaoUsuario.usuario = login;
                _context.Add(movimentacaoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Perfil,Login,Password")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioModel);
                    await MovimentoCadastro(usuarioModel.Login);
                    await _context.SaveChangesAsync();
                    TempData["MenssagemSucesso"] = "Atualização realizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!UsuarioModelExists(usuarioModel.Id))
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
            return View(usuarioModel);
        }
        public async Task<IActionResult> MovimentoAtualizacao(string login)
        {
            if (ModelState.IsValid)
            {
                MovimentacaoUsuario movimentacaoUsuario = new MovimentacaoUsuario();
                movimentacaoUsuario.DataAtualizacao = DateTime.Now;
                movimentacaoUsuario.usuario = login;
                _context.Add(movimentacaoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entidade não existe!");
            }
            var usuarioModel = await _context.Usuarios.FindAsync(id);
            if (usuarioModel != null)
            {
                _context.Usuarios.Remove(usuarioModel);
            }
            
            await _context.SaveChangesAsync();
            TempData["MenssagemSucesso"] = "Registro deletado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
