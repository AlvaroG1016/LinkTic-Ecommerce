using System;
using System.Collections.Generic;

namespace LinkTic_Ecommerce.Models.Domain;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual Usuario? Usuario { get; set; }
}
