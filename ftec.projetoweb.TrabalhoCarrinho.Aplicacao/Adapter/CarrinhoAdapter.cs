using ftec.projetoweb.TrabalhoCarrinho.Aplicacao.DTO;
using ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Aplicacao.Adapter
{
    public static class CarrinhoAdapter
    {
        public static Carrinho CarrinhoDTOTOCarrinho(CarrinhoDTO carrinhoDTO)
        {
            Carrinho carrinho = new Carrinho();

            carrinho.UsuarioId = carrinhoDTO.UsuarioId;
            carrinho.Pedidos = PedidoAdapter.PedidoDTOTOPedido(carrinhoDTO.PedidosDTO);
            carrinho.ValorTotal = carrinhoDTO.ValorTotal;

            return carrinho;
        }

        public static CarrinhoDTO CarrinhoTOCarrinhoDTO(Carrinho carrinho)
        {
            CarrinhoDTO carrinhoDTO = new CarrinhoDTO();

            carrinhoDTO.UsuarioId = carrinho.UsuarioId;
            carrinhoDTO.PedidosDTO = PedidoAdapter.PedidoTOPedidoDTO(carrinho.Pedidos);
            carrinhoDTO.ValorTotal = carrinho.ValorTotal;

            return carrinhoDTO;
        }
    }
}
