using System;
using System.Collections.Generic;

namespace LinkTic_Ecommerce.Models.Domain;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
