namespace LinkTic_Ecommerce.Models.DTO
{
    public class CrearPedidoDTO
    {
        public int UsuarioId { get; set; }
        public List<CrearDetallePedidoDTO> Detalles { get; set; } = new List<CrearDetallePedidoDTO>();
    }
}
