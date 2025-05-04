using System.ComponentModel.DataAnnotations;
using MBAModulo1.Core.Models;

namespace MBAModulo1.Core.Models
{
  public class Produto
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do Produto é obrigatório")]
    public string? Nome { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public string? Imagem { get; set; }  
  }
}