using Microsoft.AspNetCore.Mvc;
using MBAModulo1.Core.Models;
using MBAModulo1.Core.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MBAMODULO1.MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // Novo Categoria
        public IActionResult Create()
        {
            return View();
        }

        // Editar Categoria
        public IActionResult Edit(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // Excluir Categoria
        public IActionResult Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Index para exibir a lista de categorias
        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }
    }
}