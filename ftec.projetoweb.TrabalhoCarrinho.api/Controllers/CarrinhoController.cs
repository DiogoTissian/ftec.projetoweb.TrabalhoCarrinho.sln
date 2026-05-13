using ftec.projetoweb.TrabalhoCarrinho.api.Models;
using ftec.projetoweb.TrabalhoCarrinho.Aplicacao;
using ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ftec.projetoweb.TrabalhoCarrinho.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        CarrinhoAplicacao carrinhoAplicacao;
        string url_api_pedido = string.Empty;

        public CarrinhoController(IConfiguration config)
        {
            carrinhoAplicacao = new CarrinhoAplicacao(config["strConexao"]);
            this.url_api_pedido = config["url_api_pedido"];
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> Get(Guid usuarioId)
        {
            try
            {
                using HttpClient client = new HttpClient();

                string url = $"{this.url_api_pedido}/GetPedidosUsuario/{usuarioId.ToString()}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string result = await response.Content.ReadAsStringAsync();
                    List<PedidoModel> pedidosUsuario = JsonSerializer.Deserialize<List<PedidoModel>>(result, options);

                    if (pedidosUsuario.Count > 0)
                    {
                        decimal valor_total_carrinho = 0;

                        foreach (PedidoModel pedidoModel in pedidosUsuario)
                        {
                            if (pedidoModel.StatusPedido == 0)
                            {
                                pedidoModel.TextoStatusPedido = "Pendente";
                            }
                            else if (pedidoModel.StatusPedido == 1)
                            {
                                pedidoModel.TextoStatusPedido = "Concluido";
                            }
                            else if (pedidoModel.StatusPedido == -1)
                            {
                                pedidoModel.TextoStatusPedido = "Cancelado";
                            }
                            else
                            {
                                throw new ApplicationException();
                            }

                            foreach (ProdutoModel produtoModel in pedidoModel.ProdutosModel)
                            {
                                if (produtoModel.Disponivel)
                                {
                                    pedidoModel.ValorTotal += produtoModel.Preco * produtoModel.Quantidade;
                                }
                            }

                            valor_total_carrinho += pedidoModel.ValorTotal;
                        }

                        CarrinhoModel carrinhoModel = new CarrinhoModel();
                        carrinhoModel.UsuarioId = usuarioId;
                        carrinhoModel.PedidosModel = pedidosUsuario;
                        carrinhoModel.ValorTotalCarrinho = valor_total_carrinho;

                        carrinhoAplicacao.DeletarCarrinhoValorTotalPedidosAntigos(usuarioId);
                        carrinhoAplicacao.SalvarCarrinhoValorTotalPedidos(usuarioId, valor_total_carrinho);
                        return Ok(carrinhoModel);
                    }
                    else
                    {
                        return Ok("Usuário sem pedidos encontrados");
                    }
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao carregar o carrinho");
            }
        }

        [HttpPost("AtualizarStatusPedido")]
        public async Task<IActionResult> PostAtualizarStatusPedido(AtualizacaoPedidoModel atualizacaoPedidoModel)
        {
            try
            {
                using HttpClient client = new HttpClient();

                string url = $"{this.url_api_pedido}/AtualizarStatusPedido";

                HttpResponseMessage response = await client.PutAsJsonAsync(url, atualizacaoPedidoModel);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Pedido atualizado com sucesso");
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar o status do pedido");
            }
        }

        [HttpDelete("LimparCarrinho/{usuarioId}")]
        public async Task<IActionResult> DeleteLimparCarrinho(Guid usuarioId)
        {
            try
            {
                using HttpClient client = new HttpClient();

                string url = $"{this.url_api_pedido}/DeletePedidos/{usuarioId.ToString()}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Carrinho limpo com sucesso");
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao limpar o carrinho");
            }
        }

        [HttpDelete("DeletePedido/{pedidoId}")]
        public async Task<IActionResult> DeletePedido(Guid pedidoId)
        {
            try
            {
                using HttpClient client = new HttpClient();

                string url = $"{this.url_api_pedido}/{pedidoId.ToString()}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Pedido removido com sucesso");
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao remover o pedido");
            }
        }
    }
}
