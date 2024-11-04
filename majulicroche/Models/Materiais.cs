namespace majulicroche.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Nome do material
        public string Tipo { get; set; } // Tipo do material (exemplo: algodão, lã)
        public int Quantidade { get; set; } // Quantidade disponível em estoque

        // Relacionamento muitos-para-muitos com Produto
        public required ICollection<ProdutoMaterial> ProdutoMateriais { get; set; }
    }

}