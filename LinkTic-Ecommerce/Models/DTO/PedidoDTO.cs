namespace LinkTic_Ecommerce.Models.DTO
{
    public class PedidoDTO
    {
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public List<DetallePedidoDTO> Detalles { get; set; } = new List<DetallePedidoDTO>();
    }
}
