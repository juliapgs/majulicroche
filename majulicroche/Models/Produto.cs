namespace majulicroche.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Tamanho { get; set; }
        public string Cor { get; set; }
        public required decimal Valor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } // Relacionamento com Categoria
    }

}
