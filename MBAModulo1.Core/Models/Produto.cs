using System.ComponentModel.DataAnnotations;
using MBAModulo1.Core.Models;

namespace MBAModulo1.Core.Models
{
  public class Produto
  {
    public int Id { get; set; }
    public string? Nome { get; set; }
    
    public decimal Preco { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
  }
}