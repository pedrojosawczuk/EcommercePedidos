namespace EcommercePedidos.Models;
public class PedidoModel
{
    public long PedidoID { get; set; }
    public List<ItemPedidoModel>? ItensPedido { get; set; }
    private DateTime DataPedido { get; set; }
    private string? Cliente { get; set; }
    private string? Status { get; set; }
}