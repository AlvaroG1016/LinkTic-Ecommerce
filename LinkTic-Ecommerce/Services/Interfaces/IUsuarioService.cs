using LinkTic_Ecommerce.Models.DTO;

namespace LinkTic_Ecommerce.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ListarUsuarioDTO> CreateUsuarioAsync(CrearUsuarioDTO crearUsuarioDto);
    }
}
