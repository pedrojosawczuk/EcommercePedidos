using EcommercePedidos.Models;

namespace EcommercePedidos.Interfaces;

public interface IItemPedidoRepository
{
    ItemPedido GetById(long id);
    IEnumerable<ItemPedido> GetAll();
    void Add(ItemPedido itemPedido);
    void Update(ItemPedido itemPedido);
    void Remove(long id);
}