namespace LinkTic_Ecommerce.Models.DTO
{
    public class DetallePedidoDTO
    {
        public int DetalleId { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; } 
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } 
    }
}
