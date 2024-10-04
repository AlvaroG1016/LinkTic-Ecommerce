using Dropi_Dev.JwtSetup;
using Dropi_Dev.Models.CustomResponses;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkTic_Ecommerce.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly JWTUtils _jwtUtils;
        private readonly LinkticEcommerceContext _context;
        private readonly EncryptUtilities _encryptUtilities;


        public AuthService(JWTUtils jwtUtils, LinkticEcommerceContext context, EncryptUtilities encryptUtilities)
        {
            _jwtUtils = jwtUtils;
            _context = context;
            _encryptUtilities = encryptUtilities;
        }


        public async Task<AuthResponse> Login(LoginDTO loginDto)
        {


            var usuarioEncontrado = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Correo == loginDto.Correo);

            if (usuarioEncontrado == null || !_encryptUtilities.VerifyPassword(loginDto.Password, usuarioEncontrado.Password))
            {
                throw new InvalidOperationException("Correo o contraseña incorrectos");
            }

            loginDto.Password = string.Empty;


            return new AuthResponse
            {
                Correo = usuarioEncontrado.Correo,
                Token = _jwtUtils.generarJWT(usuarioEncontrado),
                NombreUsuario = usuarioEncontrado.Nombre
            };
        }
    }
}
