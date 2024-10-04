using AutoMapper;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkTic_Ecommerce.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly LinkticEcommerceContext _context;
        private readonly IMapper _mapper;

        public PedidoService(IMapper mapper, LinkticEcommerceContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        private async Task UpdateStockAsync(IEnumerable<DetallesPedido> detalles)
        {
            foreach (var detalle in detalles)
            {
                var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                if (producto != null)
                {
                    producto.CantidadEnStock -= detalle.Cantidad; 
                }
            }
            await _context.SaveChangesAsync(); 
        }


        public async Task<PedidoDTO> CreatePedidoAsync(CrearPedidoDTO crearPedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(crearPedidoDTO);
            pedido.Estado = "Pendiente";

            foreach (var detalleDTO in crearPedidoDTO.Detalles)
            {
                var producto = await _context.Productos.FindAsync(detalleDTO.ProductoId);

                if (producto == null)
                {
                    throw new Exception($"Producto con ID {detalleDTO.ProductoId} no encontrado.");
                }

                if (detalleDTO.Cantidad > producto.CantidadEnStock)
                {
                    throw new Exception($"No hay suficiente stock para el producto {producto.Nombre}. Stock disponible: {producto.CantidadEnStock}.");
                }

                var detallePedido = new DetallesPedido
                {
                    ProductoId = detalleDTO.ProductoId,
                    Cantidad = detalleDTO.Cantidad,
                    PrecioUnitario = producto.Precio
                };

                
                pedido.DetallesPedidos.Add(detallePedido);
            }

            await _context.Pedidos.AddAsync(pedido); 
            await _context.SaveChangesAsync();

            // Actualizar el stock después de guardar el pedido
            await UpdateStockAsync(pedido.DetallesPedidos);

            var responsePedido = _mapper.Map<PedidoDTO>(pedido);

            return responsePedido;
        }



        public async Task<List<PedidoDTO>> GetAllPedidosAsync()
        {
            // Obtener todos los pedidos de la base de datos
            var pedidos = await _context.Pedidos.Include(p => p.DetallesPedidos)
                                                  .ThenInclude(dp => dp.Producto) 
                                                  .ToListAsync();

      
            var responsePedidosDTO = _mapper.Map<List<PedidoDTO>>(pedidos);

            return responsePedidosDTO;
        }

    }
}
