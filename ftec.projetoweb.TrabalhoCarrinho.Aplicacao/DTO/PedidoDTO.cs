using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Aplicacao.DTO
{
    public class PedidoDTO
    {
        public PedidoDTO()
        {
            this.Id = Guid.Empty;
            this.UsuarioId = Guid.Empty;
            this.ProdutosDTO = new List<ProdutoDTO>();
            this.DataPedido = DateTime.MinValue;
        }

        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public List<ProdutoDTO> ProdutosDTO { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
