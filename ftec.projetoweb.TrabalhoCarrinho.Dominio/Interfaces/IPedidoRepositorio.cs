using ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Dominio.Interfaces
{
    public interface IPedidoRepositorio
    {
        void SalvarCarrinhoValorTotalPedidos(Guid usuarioId, decimal valor_total_carrinho);
        void DeletarCarrinhoValorTotalPedidosAntigos(Guid usuarioId);
    }
}
