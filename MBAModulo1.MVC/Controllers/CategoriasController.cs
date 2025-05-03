using Microsoft.AspNetCore.Mvc;
using MBAModulo1.Core.Models;
using MBAModulo1.Core.Data;

namespace MBAMODULO1.MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // Ação para criar uma nova categoria
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);  // Adiciona a nova categoria
                await _context.SaveChangesAsync();    // Salva no banco de dados
                return RedirectToAction(nameof(Index));  // Redireciona para a lista de categorias
            }
            return View(categoria);
        }

        // Index para exibir todas as categorias
        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }
    }
}
