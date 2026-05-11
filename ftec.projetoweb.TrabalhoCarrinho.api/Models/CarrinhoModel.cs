namespace ftec.projetoweb.TrabalhoCarrinho.api.Models
{
    public class CarrinhoModel
    {
        public CarrinhoModel()
        {
            this.UsuarioId = Guid.Empty;
            this.PedidosModel = new List<PedidoModel>();
            this.ValorTotal = 0;
        }

        public Guid UsuarioId { get; set; }
        public List<PedidoModel> PedidosModel { get; set; }
        public double ValorTotal { get; set; }
    }
}
