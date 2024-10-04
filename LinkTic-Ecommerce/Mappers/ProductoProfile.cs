using AutoMapper;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Models.DTO;

namespace LinkTic_Ecommerce.Mappers
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<CrearProductoDTO, Producto>()
           .ForMember(dest => dest.FechaCreación, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Producto, ProductoDTO>();
        }
    }
}
