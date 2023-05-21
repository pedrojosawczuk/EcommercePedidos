namespace EcommercePedidos.Models;

public class ItemPedidoModel
{
    public long ItemPedidoID { get; set; }
    public string? Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public long PedidoID { get; set; }
    public PedidoModel? Pedido { get; set; }
}