namespace ftec.projetoweb.TrabalhoCarrinho.api.Models
{
    public class AtualizacaoPedidoModel
    {
        public AtualizacaoPedidoModel()
        {
            this.PedidoId = Guid.Empty;
            this.StatusPedido = 0;
        }

        public Guid PedidoId { get; set; }
        public int StatusPedido { get; set; }
    }
}
