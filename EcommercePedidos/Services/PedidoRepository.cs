using MySql.Data.MySqlClient;

using EcommercePedidos.Models;
using EcommercePedidos.Interfaces;

namespace EcommercePedidos.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly string _connectionString;

    public PedidoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InserirPedido(PedidoModel pedido)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            var sql = "INSERT INTO Pedido (DataPedido, Cliente, StatusPedido) VALUES (@DataPedido, @Cliente, @StatusPedido); SELECT LAST_INSERT_ID();";
            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
            cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);
            cmd.Parameters.AddWithValue("@StatusPedido", pedido.Status);

            var idPedido = cmd.ExecuteScalar();
            pedido.PedidoID = Convert.ToInt64(idPedido);
        }
    }


    public void AtualizarPedido(PedidoModel pedido)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            string query = "UPDATE Pedido SET DataPedido = @DataPedido, Cliente = @Cliente, StatusPedido = @StatusPedido WHERE PedidoId = @PedidoId";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
                command.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                command.Parameters.AddWithValue("@StatusPedido", pedido.Status);
                command.Parameters.AddWithValue("@PedidoId", pedido.PedidoID);

                int rowsAffected = command.ExecuteNonQuery();
            }

        }
    }

    public PedidoModel ObterPedidoPorId(long id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            var query = "SELECT PedidoId, DataPedido, Cliente, StatusPedido FROM Pedido WHERE PedidoId = @Id";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var pedidoReader = command.ExecuteReader())
                {
                    if (pedidoReader.Read())
                    {
                        var pedido = new PedidoModel
                        {
                            PedidoID = pedidoReader.GetInt64("PedidoID"),
                            DataPedido = pedidoReader.GetDateTime("dataPedido"),
                            Cliente = pedidoReader.GetString("cliente"),
                            Status = pedidoReader.GetString("status")
                        };

                        return pedido;
                    }
                }
            }
        }
        return null;
    }


    public IEnumerable<PedidoModel> ObterTodosOsPedidos()
    {
        List<PedidoModel> pedidos = new List<PedidoModel>();

        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT Id, DataPedido, Cliente, Status FROM Pedido";

            using (var command = new MySqlCommand(query, connection))
            {
                using (var pedidoReader = command.ExecuteReader())
                {
                    while (pedidoReader.Read())
                    {
                        PedidoModel pedido = new PedidoModel
                        {
                            PedidoID = pedidoReader.GetInt64("ItemPedidoID"),
                            DataPedido = pedidoReader.GetDateTime("Produto"),
                            Cliente = pedidoReader.GetString("Quantidade"),
                            Status = pedidoReader.GetString("Status")
                        };

                        pedidos.Add(pedido);
                    }
                }
            }
            return pedidos;
        }
    }
    public void ExcluirPedido(long id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            var query = "DELETE FROM ItemPedido WHERE PedidoId = @PedidoId";

            using (var command = new MySqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@PedidoId", id);

                command.ExecuteNonQuery();
            }
        }
    }
}