using ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades;
using ftec.projetoweb.TrabalhoCarrinho.Dominio.Interfaces;
using ftec.projetoweb.TrabalhoCarrinho.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftec.projetoweb.TrabalhoCarrinho.Aplicacao
{
    public class CarrinhoAplicacao
    {
        IPedidoRepositorio pedidoRepositorio;
        private string strConexao = string.Empty;

        public CarrinhoAplicacao(string strConexao)
        {
            pedidoRepositorio = new PedidoRepository(strConexao);
        }

        public void SalvarCarrinhoValorTotalPedidos(Guid usuarioId, double valor_total)
        {
            try
            {
                pedidoRepositorio.SalvarCarrinhoValorTotalPedidos(usuarioId, valor_total);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarCarrinhoValorTotalPedidosAntigos(Guid usuarioId)
        {
            try
            {
                pedidoRepositorio.DeletarCarrinhoValorTotalPedidosAntigos(usuarioId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
