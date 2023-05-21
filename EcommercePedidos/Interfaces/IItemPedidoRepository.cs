using EcommercePedidos.Models;

namespace EcommercePedidos.Interfaces;

public interface IItemPedidoRepository
{
    void InserirItemPedido(ItemPedidoModel itemPedido);
    void AtualizarItemPedido(ItemPedidoModel itemPedido);
    ItemPedidoModel? ObterItemPedidoPorId(long id);
    IEnumerable<ItemPedidoModel> ObterTodosOsItensPedidos();
    void ExcluirItemPedido(long id);
}