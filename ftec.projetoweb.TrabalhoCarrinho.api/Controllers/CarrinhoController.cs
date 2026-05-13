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
                if (usuarioId != null && usuarioId != Guid.Empty)
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
                            return BadRequest("Busca pedidos usuário - Usuário sem pedidos encontrados");
                        }
                    }
                    else
                    {
                        return BadRequest("Busca pedidos usuário - Problema ao consultar os pedidos");
                    }
                }
                else
                {
                    return BadRequest("Busca pedidos usuário - Id de usuário inválido");
                }
            }
            catch (Exception)
            {
                return BadRequest("Busca pedidos usuário - Erro ao carregar o carrinho do usuário");
            }
        }

        [HttpPost("AtualizarStatusPedido")]
        public async Task<IActionResult> PostAtualizarStatusPedido(AtualizacaoPedidoModel atualizacaoPedidoModel)
        {
            try
            {
                if (atualizacaoPedidoModel != null)
                {
                    if (atualizacaoPedidoModel.PedidoId == null || atualizacaoPedidoModel.PedidoId == Guid.Empty)
                    {
                        return BadRequest("Atualizar Status Pedido - Erro ao atualizar o status do pedido. Id do pedido inválido");
                    }

                    if (atualizacaoPedidoModel.StatusPedido < -1 || atualizacaoPedidoModel.StatusPedido > 1)
                    {
                        return BadRequest("Atualizar Status Pedido - Erro ao atualizar o status do pedido. Status do pedido inválido");
                    }

                    using HttpClient client = new HttpClient();

                    string url = $"{this.url_api_pedido}/AtualizarStatusPedido";

                    HttpResponseMessage response = await client.PutAsJsonAsync(url, atualizacaoPedidoModel);

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Atualizar Status Pedido - Pedido atualizado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Atualizar Status Pedido - Erro ao atualizar o status do pedido");
                    }
                }
                else
                {
                    return BadRequest("Atualizar Status Pedido - Dados recebidos para atualização de pedido corrompidos");
                }
            }
            catch (Exception)
            {
                return BadRequest("Atualizar Status Pedido - Erro ao atualizar o status do pedido");
            }
        }

        [HttpDelete("LimparCarrinho/{usuarioId}")]
        public async Task<IActionResult> DeleteLimparCarrinho(Guid usuarioId)
        {
            try
            {
                if (usuarioId != null && usuarioId != Guid.Empty)
                {
                    using HttpClient client = new HttpClient();

                    string url = $"{this.url_api_pedido}/DeletePedidos/{usuarioId.ToString()}";

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Limpar Carrinho Usuário - Carrinho limpo com sucesso");
                    }
                    else
                    {
                        return BadRequest("Limpar Carrinho Usuário - Erro ao limpar o carrinho");
                    }
                }
                else
                {
                    return BadRequest("Limpar Carrinho Usuário - Id de usuário inválido");
                }
            }
            catch (Exception)
            {
                return BadRequest("Limpar Carrinho Usuário - Erro ao limpar o carrinho");
            }
        }

        [HttpDelete("DeletePedido/{pedidoId}")]
        public async Task<IActionResult> DeletePedido(Guid pedidoId)
        {
            try
            {
                if (pedidoId != null && pedidoId != Guid.Empty)
                {
                    using HttpClient client = new HttpClient();

                    string url = $"{this.url_api_pedido}/{pedidoId.ToString()}";

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Deletar Pedido - Pedido removido com sucesso");
                    }
                    else
                    {
                        return BadRequest("Deletar Pedido - Erro ao remover o pedido");
                    }
                }
                else
                {
                    return BadRequest("Deletar Pedido - Id do pedido inválido");
                }
            }
            catch (Exception)
            {
                return BadRequest("Deletar Pedido - Erro ao remover o pedido");
            }
        }
    }
}
