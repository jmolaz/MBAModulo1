namespace MBAMODULO1.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Relacionamento com Produto
        public ICollection<Produto>? Produtos { get; set; }
    }
}