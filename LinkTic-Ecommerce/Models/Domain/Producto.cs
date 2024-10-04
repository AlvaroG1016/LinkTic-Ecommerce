using System;
using System.Collections.Generic;

namespace LinkTic_Ecommerce.Models.Domain;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public decimal? Precio { get; set; }

    public int? CantidadEnStock { get; set; }

    public DateTime? FechaCreación { get; set; }

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();
}
