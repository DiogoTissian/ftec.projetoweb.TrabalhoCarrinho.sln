using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Aplicacao.DTO
{
    public class CarrinhoDTO
    {
        public CarrinhoDTO()
        {
            this.UsuarioId = Guid.Empty;
            this.PedidosDTO = new List<PedidoDTO>();
            this.ValorTotal = 0;
        }

        public Guid UsuarioId { get; set; }
        public List<PedidoDTO> PedidosDTO { get; set; }
        public double ValorTotal { get; set; }
    }
}
