using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {
            this.Id = Guid.Empty;
            this.PedidoId = Guid.Empty;
            this.ProdutoId = Guid.Empty;
            this.Quantidade = 0;
        }

        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
