using AutoMapper;
using Dropi_Dev.JwtSetup;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Models.DTO;


namespace Dropi_Dev.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            ;
            //CreateMap<CrearUsuarioDTO, Usuario>()
            //    .ForMember(u => u.Password, cud => cud.MapFrom(cud => encrypt.HashPassword(cud.Password)));
            CreateMap<CrearUsuarioDTO, Usuario>()
            .ForMember(u => u.Password, opts => opts.Ignore());

            CreateMap<Usuario, ListarUsuarioDTO>();

        }
    }
}
