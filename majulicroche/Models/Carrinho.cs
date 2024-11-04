namespace majulicroche.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public decimal ValorTotal
        {
            get
            {
                return Produtos.Sum(p => p.Valor);
            }
        }
    }
}
