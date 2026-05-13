using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades
{
    public class Carrinho
    {
        public Carrinho()
        {
            this.UsuarioId = Guid.Empty;
            this.Pedidos = new List<Pedido>();
            this.ValorTotalCarrinho = 0;
        }

        public Guid UsuarioId { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public decimal ValorTotalCarrinho { get; set; }
    }
}
