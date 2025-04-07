using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MBAMODULO1.Data;
using MBAMODULO1.Models;

namespace MBAMODULO1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return NotFound();

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Categoria categoria)
        {
            if (id != categoria.Id)
                return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return NotFound();

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
