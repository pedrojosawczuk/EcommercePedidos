namespace EcommercePedidos.Models;

public class ItemPedidoModel
{
    public int ItemPedidoID { get; set; }
    private string? Produto { get; set; }
    private int Quantidade { get; set; }
    private decimal PrecoUnitario { get; set; }
    private PedidoModel? Pedido { get; set; }
}