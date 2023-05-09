using EcommercePedidos.Models;

namespace EcommercePedidos.Interfaces;

public interface IPedidoRepository
{
    void Inserir(Pedido pedido);
    void Atualizar(Pedido pedido);
    void Excluir(int id);
    Pedido ObterPorId(int id);
    List<Pedido> ObterTodos();
}