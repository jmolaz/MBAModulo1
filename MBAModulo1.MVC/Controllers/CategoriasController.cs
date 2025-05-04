using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBAModulo1.Core.Models;
using MBAModulo1.Core.Data;
using Microsoft.AspNetCore.Authorization;

namespace MBAMODULO1.MVC.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return View(categorias);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();

            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();

            // Verifica se há produtos associados a essa categoria
            bool possuiProdutos = await _context.Produtos.AnyAsync(p => p.CategoriaId == id);

            if (possuiProdutos)
            {
                TempData["Erro"] = "Não é possível excluir a categoria, pois ela está vinculada a produtos.";
                return RedirectToAction(nameof(Index));
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // Confirma se a Categoria não está vinculada a um produto

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
