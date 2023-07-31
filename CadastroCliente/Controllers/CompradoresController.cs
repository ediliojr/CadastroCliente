using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Data;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace CadastroCliente.Controllers
{
    [Authorize]

    public class CompradoresController : Controller
    {
        private readonly CadastroClienteContext _context;

        public CompradoresController(CadastroClienteContext context)
        {
            _context = context;
        }

        // GET: Compradores

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {


            var compradores = _context.Comprador.AsQueryable();

            // Apply filtering if searchString is provided
            if (!string.IsNullOrEmpty(searchString))
            {
                compradores = compradores.Where(c =>
                    c.Nome.Contains(searchString) ||
                    c.Email.Contains(searchString) ||
                    c.Telefone.Contains(searchString)
                // Add more attributes for filtering as needed
                );
            }

            // Apply sorting based on sortOrder
            switch (sortOrder)
            {
                case "Nome_desc":
                    compradores = compradores.OrderByDescending(c => c.Nome);
                    break;
                case "Email":
                    compradores = compradores.OrderBy(c => c.Email);
                    break;
                case "Email_desc":
                    compradores = compradores.OrderByDescending(c => c.Email);
                    break;
                case "Telefone":
                    compradores = compradores.OrderBy(c => c.Telefone);
                    break;
                case "Telefone_desc":
                    compradores = compradores.OrderByDescending(c => c.Telefone);
                    break;
                // Add more cases for sorting other attributes as needed
                default:
                    compradores = compradores.OrderBy(c => c.Nome);
                    break;
            }

            return _context.Comprador != null ?
                          View(await _context.Comprador.ToListAsync()) :
                          Problem("Entity set 'CadastroClienteContext.Comprador'  is null.");
        }

        // GET: Compradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comprador == null)
            {
                return NotFound();
            }

            var comprador = await _context.Comprador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comprador == null)
            {
                return NotFound();
            }

            return View(comprador);
        }

        // GET: Compradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Cpf,Telefone,DataCadastro,ClienteBloqueado")] Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comprador);
        }

        // GET: Compradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comprador == null)
            {
                return NotFound();
            }

            var comprador = await _context.Comprador.FindAsync(id);
            if (comprador == null)
            {
                return NotFound();
            }
            return View(comprador);
        }

        // POST: Compradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Cpf,Telefone,DataCadastro,ClienteBloqueado")] Comprador comprador)
        {
            if (id != comprador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompradorExists(comprador.Id))
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
            return View(comprador);
        }

        // GET: Compradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comprador == null)
            {
                return NotFound();
            }

            var comprador = await _context.Comprador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comprador == null)
            {
                return NotFound();
            }

            return View(comprador);
        }

        // POST: Compradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comprador == null)
            {
                return Problem("Entity set 'CadastroClienteContext.Comprador'  is null.");
            }
            var comprador = await _context.Comprador.FindAsync(id);
            if (comprador != null)
            {
                _context.Comprador.Remove(comprador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompradorExists(int id)
        {
            return (_context.Comprador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
