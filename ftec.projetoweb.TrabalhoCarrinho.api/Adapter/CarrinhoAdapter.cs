using ftec.projetoweb.TrabalhoCarrinho.api.Models;
using ftec.projetoweb.TrabalhoCarrinho.Aplicacao.DTO;

namespace ftec.projetoweb.TrabalhoCarrinho.api.Adapter
{
    public class CarrinhoAdapter
    {
        public static CarrinhoModel CarrinhoDTOTOCarrinhoModel(CarrinhoDTO carrinhoDTO)
        {
            CarrinhoModel carrinhoModel = new CarrinhoModel();

            carrinhoModel.UsuarioId = carrinhoDTO.UsuarioId;
            carrinhoModel.PedidosModel = PedidoAdapter.PedidoDTOTOPedidoModel(carrinhoDTO.PedidosDTO);
            carrinhoModel.ValorTotal = carrinhoDTO.ValorTotal;

            return carrinhoModel;
        }

        public static CarrinhoDTO CarrinhoModelTOCarrinhoDTO(CarrinhoModel carrinhoModel)
        {
            CarrinhoDTO carrinhoDTO = new CarrinhoDTO();

            carrinhoDTO.UsuarioId = carrinhoModel.UsuarioId;
            carrinhoDTO.PedidosDTO = PedidoAdapter.PedidoModelTOPedidoDTO(carrinhoModel.PedidosModel);
            carrinhoDTO.ValorTotal = carrinhoModel.ValorTotal;

            return carrinhoDTO;
        }
    }
}
