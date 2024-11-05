using System.ComponentModel.DataAnnotations;

namespace majulicroche.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do material é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo do material é obrigatório.")]
        public string Tipo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        // Relacionamento muitos-para-muitos com Produto
        public required ICollection<ProdutoMaterial> ProdutoMateriais { get; set; }
    }

}