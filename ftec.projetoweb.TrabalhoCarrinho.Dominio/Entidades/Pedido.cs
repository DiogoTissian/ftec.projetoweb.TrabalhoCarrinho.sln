using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            this.Id = Guid.Empty;
            this.UsuarioId = Guid.Empty;
            this.Produtos = new List<Produto>();
            this.DataPedido = DateTime.MinValue;
        }

        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
