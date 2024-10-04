namespace LinkTic_Ecommerce.Models.DTO
{
    public class ListarUsuarioDTO
    {
        public int UsuarioId { get; set; }

        public string? Nombre { get; set; }

        public string? Correo { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
