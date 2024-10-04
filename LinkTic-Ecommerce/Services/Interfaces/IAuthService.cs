using Dropi_Dev.Models.CustomResponses;
using LinkTic_Ecommerce.Models.DTO;

namespace LinkTic_Ecommerce.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginDTO loginDTO);

    }
}
