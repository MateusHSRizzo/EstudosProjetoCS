using EstudoProjetoCS.Data;
using EstudoProjetoCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstudoProjetoCS.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto _contexto;

        public ClientesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var contexto = _contexto.Clientes;
            return View(await contexto.ToListAsync());
        }

        public IActionResult Criar()
        {
            return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _contexto.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Nome,Contato,Email,Documento,Genero,Nascimento,Endereco")] ClienteModel cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(cliente);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null || _contexto.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_contexto.Clientes == null)
            {
                return Problem("Entidade setada 'Contexto.Clientes'  está vazio.");
            }
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _contexto.Clientes.Remove(cliente);
            }

            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if(id == null || _contexto.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Nome,Contato,Email,Documento,Genero,Nascimento,Endereco")] ClienteModel cliente) 
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(cliente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        private bool ClienteExists(int id)
        {
            return _contexto.Clientes.Any(e => e.Id == id);
        }
    }
}
