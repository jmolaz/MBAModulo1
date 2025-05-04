using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBAModulo1.Core.Data;
using MBAModulo1.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MBAModulo1.MVC.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();
            return View(produtos);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto, IFormFile imagem)
        {
            if (imagem != null && imagem.Length > 0)
            {
                var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                var caminhoImagem = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ImagensProdutos", nomeArquivo);

                using (var stream = new FileStream(caminhoImagem, FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                }

                produto.Imagem = "/ImagensProdutos/" + nomeArquivo;
            }

            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET: Produtos
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return NotFound();

            ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Produtos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto, IFormFile imagem)
        {
            if (id != produto.Id) return NotFound();

            var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == produto.CategoriaId);
            if (!categoriaExiste)
            {
                ModelState.AddModelError("CategoriaId", "Categoria selecionada não existe.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imagem != null && imagem.Length > 0)
                    {
                        var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                        var caminhoImagem = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ImagensProdutos", nomeArquivo);

                        using (var stream = new FileStream(caminhoImagem, FileMode.Create))
                        {
                            await imagem.CopyToAsync(stream);
                        }

                        produto.Imagem = "/ImagensProdutos/" + nomeArquivo;
                    }

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Produtos.Any(p => p.Id == id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null) return NotFound();

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
