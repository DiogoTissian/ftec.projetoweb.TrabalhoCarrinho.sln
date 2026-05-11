using ftec.projetoweb.TrabalhoCarrinho.Dominio.Entidades;
using ftec.projetoweb.TrabalhoCarrinho.Dominio.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ftec.projetoweb.TrabalhoCarrinho.ExternalService
{
    public class PedidoRepository : IPedidoRepositorio
    {
        private string strConexao = string.Empty;

        public PedidoRepository(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public void SalvarCarrinhoValorTotalPedidos(Guid usuarioId, double valor_total)
        {
            try
            {
                using (var conexao = new NpgsqlConnection(strConexao))
                {
                    conexao.Open();

                    var sqlCommand = new NpgsqlCommand();
                    sqlCommand.Connection = conexao;

                    Guid pedidoId = Guid.NewGuid();

                    sqlCommand.CommandText = "INSERT INTO carrinho (id, usuarioid, valor_total) VALUES (@id, @usuarioid, @valor_total)";
                    sqlCommand.Parameters.AddWithValue("id", Guid.NewGuid());
                    sqlCommand.Parameters.AddWithValue("usuarioid", usuarioId);
                    sqlCommand.Parameters.AddWithValue("valor_total", valor_total);
                    sqlCommand.ExecuteNonQuery();
                }
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
                using (var conexao = new NpgsqlConnection(strConexao))
                {
                    conexao.Open();

                    var sqlCommand = new NpgsqlCommand();
                    sqlCommand.Connection = conexao;

                    Guid pedidoId = Guid.NewGuid();

                    sqlCommand.CommandText = "DELETE FROM carrinho WHERE usuarioid = @usuarioid";
                    sqlCommand.Parameters.AddWithValue("usuarioid", usuarioId);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
