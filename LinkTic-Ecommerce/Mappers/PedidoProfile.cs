using AutoMapper;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Models.DTO;

namespace LinkTic_Ecommerce.Mappers
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<CrearPedidoDTO, Pedido>()
             .ForMember(dest => dest.FechaPedido, opt => opt.MapFrom(src => DateTime.Now)); // Asignamos la fecha actual

            // Mapeo de CrearDetallePedidoDTO a DetallesPedido
            CreateMap<CrearDetallePedidoDTO, DetallesPedido>();

            // Mapeo de Pedido a PedidoDTO
            CreateMap<Pedido, PedidoDTO>()
                .ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.DetallesPedidos));

            // Mapeo de DetallesPedido a DetallePedidoDTO
            CreateMap<DetallesPedido, DetallePedidoDTO>()
                .ForMember(dest => dest.ProductoNombre, opt => opt.MapFrom(src => src.Producto.Nombre)) 
                .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.Producto.Precio));
        }
    }
}
