using Microsoft.AspNetCore.Mvc;
using MBAModulo1.Core.Models;
using MBAModulo1.Core.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MBAMODULO1.MVC.Controllers
{
  public class ProdutosController : Controller
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    // Index para listar produtos
    public IActionResult Index()
    {
        var produtos = _context.Produtos.ToList();
        return View(produtos);
    }

    // Novo Produto
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(produto);
    }

    // Editar Produto
    public IActionResult Edit(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Produtos.Any(p => p.Id == produto.Id))
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
        return View(produto);
    }

    // Excluir Produto
    public IActionResult Delete(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var produto = _context.Produtos.Find(id);
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

}
