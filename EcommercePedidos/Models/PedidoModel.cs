namespace EcommercePedidos.Models;

public class PedidoModel
{
    public long PedidoID { get; set; }
    public ICollection<ItemPedidoModel>? ItensPedido { get; set; }
    public DateTime DataPedido { get; set; }
    public string? Cliente { get; set; }
    public string? Status { get; set; }
}