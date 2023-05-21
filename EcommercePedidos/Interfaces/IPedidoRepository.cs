using EcommercePedidos.Models;

namespace EcommercePedidos.Interfaces;

public interface IPedidoRepository
{
    void InserirPedido(PedidoModel pedido);
    void AtualizarPedido(PedidoModel pedido);
    PedidoModel? ObterPedidoPorId(long id);
    IEnumerable<PedidoModel> ObterTodosOsPedidos();
    void ExcluirPedido(long id);
}