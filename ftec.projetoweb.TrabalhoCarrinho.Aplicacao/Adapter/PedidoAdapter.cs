using ftec.projetoweb.TrabalhoCarrinho.Aplicacao.DTO;
using ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Aplicacao.Adapter
{
    public static class PedidoAdapter
    {
        public static PedidoDTO PedidoTOPedidoDTO(Pedido pedido)
        {
            PedidoDTO pedidoDTO = new PedidoDTO();

            pedidoDTO.Id = pedido.Id;
            pedidoDTO.UsuarioId = pedido.UsuarioId;
            pedidoDTO.ProdutosDTO = ProdutoAdapter.ProdutoTOProdutoDTO(pedido.Produtos, pedido.Id);
            pedidoDTO.DataPedido = pedido.DataPedido;

            return pedidoDTO;
        }

        public static List<PedidoDTO> PedidoTOPedidoDTO(List<Pedido> pedidos)
        {
            List<PedidoDTO> pedidosDTO = new List<PedidoDTO>();

            foreach (Pedido pedido in pedidos)
            {
                pedidosDTO.Add(new PedidoDTO()
                {
                    Id = pedido.Id,
                    UsuarioId = pedido.UsuarioId,
                    ProdutosDTO = ProdutoAdapter.ProdutoTOProdutoDTO(pedido.Produtos, pedido.Id),
                    DataPedido = pedido.DataPedido
                });
            }

            return pedidosDTO;
        }

        public static Pedido PedidoDTOTOPedido(PedidoDTO pedidoDTO)
        {
            Pedido pedido = new Pedido();

            pedido.Id = pedidoDTO.Id;
            pedido.UsuarioId = pedidoDTO.UsuarioId;
            pedido.Produtos = ProdutoAdapter.ProdutoDTOTOProduto(pedidoDTO.ProdutosDTO, pedidoDTO.Id);
            pedido.DataPedido = pedidoDTO.DataPedido;

            return pedido;
        }

        public static List<Pedido> PedidoDTOTOPedido(List<PedidoDTO> pedidosDTO)
        {
            List<Pedido> pedidos = new List<Pedido>();

            foreach (PedidoDTO pedidoDTO in pedidosDTO)
            {
                pedidos.Add(new Pedido()
                {
                    Id = pedidoDTO.Id,
                    UsuarioId = pedidoDTO.UsuarioId,
                    Produtos = ProdutoAdapter.ProdutoDTOTOProduto(pedidoDTO.ProdutosDTO, pedidoDTO.Id),
                    DataPedido = pedidoDTO.DataPedido
                });
            }

            return pedidos;
        }
    }
}
