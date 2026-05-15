namespace ftec.projetoweb.TrabalhoCarrinho.api.Models
{
    public class ProdutoModel
    {
        public ProdutoModel()
        {
            this.Id = Guid.Empty;
            this.PedidoId = Guid.Empty;
            this.ProdutoId = Guid.Empty;
            this.Quantidade = 0;
            this.Preco = 0;
            this.Disponivel = false;
        }

        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public bool Disponivel { get; set; }
    }
}
