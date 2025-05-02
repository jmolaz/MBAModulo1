using MBAModulo1.Core.Models;

namespace MBAModulo1.Core.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        // Relacionamento com Produto
        public ICollection<Produto>? Produtos { get; set; }
    }
}