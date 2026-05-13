namespace ftec.projetoweb.TrabalhoCarrinho.api.Models
{
    public class PedidoModel
    {
        public PedidoModel()
        {
            this.Id = Guid.Empty;
            this.UsuarioId = Guid.Empty;
            this.ProdutosModel = new List<ProdutoModel>();
            this.DataPedido = DateTime.MinValue;
            this.StatusPedido = 0;
            this.TextoStatusPedido = string.Empty;
            this.ValorTotal = 0;
            this.CEPEnderecoEntrega = string.Empty;
            this.NumeroEnderecoEntrega = string.Empty;
        }

        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public List<ProdutoModel> ProdutosModel { get; set; }
        public DateTime DataPedido { get; set; }
        public int StatusPedido { get; set; }
        public string TextoStatusPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string CEPEnderecoEntrega { get; set; }
        public string NumeroEnderecoEntrega { get; set; }
    }
}
