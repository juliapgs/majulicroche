namespace majulicroche.Models
{
    public class ControleEstoque
    {
        public int Id { get; set; }
        public string NomeMaterial { get; set; }
        public int Quantidade { get; set; }
        public string UnidadeMedida { get; set; } // Exemplo: metros, rolos, etc.
        public string Fornecedor { get; set; }
        public DateTime DataUltimoReabastecimento { get; set; }
    }
}
