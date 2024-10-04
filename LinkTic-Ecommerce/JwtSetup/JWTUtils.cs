
using LinkTic_Ecommerce.Models.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Dropi_Dev.JwtSetup
{
    public class JWTUtils
    {

        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;

        public JWTUtils(IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            _configuration = configuration;
            _jwtSettings = jwtSettings.Value; 
        }




        public string generarJWT(Usuario modelo)
        {
            //Crear informacion del usuario para el token 

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.UsuarioId.ToString()),
                new Claim(ClaimTypes.Email, modelo.Correo!)

            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Crear el detalle del token

            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: credentials

            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }

    }
}
