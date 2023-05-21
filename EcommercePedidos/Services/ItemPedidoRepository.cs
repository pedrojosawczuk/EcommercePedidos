using MySql.Data.MySqlClient;

using EcommercePedidos.Models;
using EcommercePedidos.Interfaces;

namespace EcommercePedidos.Repositories;

public class ItemPedidoRepository : IItemPedidoRepository
{
    private readonly string _connectionString;

    public ItemPedidoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InserirItemPedido(ItemPedidoModel itemPedido)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            var query = "INSERT INTO ItemPedido (Produto, Quantidade, PrecoUnitario, PedidoId) VALUES (@Produto, @Quantidade, @PrecoUnitario, @PedidoId)";
            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Produto", itemPedido.Produto);
            cmd.Parameters.AddWithValue("@Quantidade", itemPedido.Quantidade);
            cmd.Parameters.AddWithValue("@PrecoUnitario", itemPedido.PrecoUnitario);

            cmd.ExecuteNonQuery();
        }
    }

    public void AtualizarItemPedido(ItemPedidoModel itemPedido)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            var sql = "UPDATE ItemPedido SET Produto = @Produto, Quantidade = @Quantidade, PrecoUnitario = @PrecoUnitario, PedidoId = @PedidoId WHERE ItemPedidoID = @ItemPedidoID";
            var cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Produto", itemPedido.Produto);
            cmd.Parameters.AddWithValue("@Quantidade", itemPedido.Quantidade);
            cmd.Parameters.AddWithValue("@PrecoUnitario", itemPedido.PrecoUnitario);
            cmd.Parameters.AddWithValue("@ItemPedidoID", itemPedido.ItemPedidoID);

            cmd.ExecuteNonQuery();
        }
    }

    public ItemPedidoModel? ObterItemPedidoPorId(long id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT ItemPedidoID, Produto, Quantidade, PrecoUnitario, PedidoID FROM ItemPedido WHERE ItemPedidoID = @Id";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var itemReader = command.ExecuteReader())
                {
                    if (itemReader.Read())
                    {
                        var itemPedido = new ItemPedidoModel
                        {
                            ItemPedidoID = itemReader.GetInt64("ItemPedidoID"),
                            Produto = itemReader.GetString("Produto"),
                            Quantidade = itemReader.GetInt32("Quantidade"),
                            Pedido = new PedidoModel { PedidoID = itemReader.GetInt64("PedidoID") }
                        };

                        return itemPedido;
                    }
                }
            }
        }

        return null;
    }
    

    public IEnumerable<ItemPedidoModel> ObterTodosOsItensPedidos()
    {
        List<ItemPedidoModel> itensPedidos = new List<ItemPedidoModel>();

        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            string query = "SELECT ItemPedidoID, Produto, Quantidade, PrecoUnitario, PedidoID FROM ItemPedido";

            using (var command = new MySqlCommand(query, connection))
            {
                using (var itemReader = command.ExecuteReader())
                {
                    while (itemReader.Read())
                    {
                        var itemPedido = new ItemPedidoModel
                        {
                            ItemPedidoID = itemReader.GetInt64("ItemPedidoID"),
                            Produto = itemReader.GetString("Produto"),
                            Quantidade = itemReader.GetInt32("Quantidade"),
                            Pedido = new PedidoModel { PedidoID = itemReader.GetInt64("PedidoID") }
                        };

                        itensPedidos.Add(itemPedido);
                    }
                }
            }
        }

        return itensPedidos;
    }


    public void ExcluirItemPedido(long id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            var query = "DELETE FROM ItemPedido WHERE PedidoId = @PedidoId";

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@PedidoId", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}