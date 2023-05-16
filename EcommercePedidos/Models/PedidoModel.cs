namespace EcommercePedidos.Models;
public class Pedido
{
    public int PedidoID { get; set; }
    private DateTime _dataPedido { get; set; }
    private string? _cliente { get; set; }
    private string? _status { get; set; }
}