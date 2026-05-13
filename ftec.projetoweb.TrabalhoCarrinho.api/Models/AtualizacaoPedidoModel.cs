namespace ftec.projetoweb.TrabalhoCarrinho.api.Models
{
    public class AtualizacaoPedidoModel
    {
        public AtualizacaoPedidoModel()
        {
            this.PedidoId = Guid.Empty;
            this.StatusPedido = 0;
            this.CEPEnderecoEntrega = string.Empty;
            this.NumeroEnderecoEntrega = string.Empty;
        }

        public Guid PedidoId { get; set; }
        public int StatusPedido { get; set; }
        public string CEPEnderecoEntrega { get; set; }
        public string NumeroEnderecoEntrega { get; set; }
    }
}
