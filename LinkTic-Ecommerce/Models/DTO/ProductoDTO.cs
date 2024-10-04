namespace LinkTic_Ecommerce.Models.DTO
{
    public class ProductoDTO
    {
        public int ProductoId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripción { get; set; }

        public decimal? Precio { get; set; }

        public int? CantidadEnStock { get; set; }

        public DateTime? FechaCreación { get; set; }
    }
}
