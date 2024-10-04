using AutoMapper;
using Dropi_Dev.JwtSetup;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkTic_Ecommerce.Services.Implementations
{
    public class UsuarioService :IUsuarioService
    {
        private readonly LinkticEcommerceContext _context;
        private readonly IMapper _mapper;
        private readonly EncryptUtilities _encrypt;


        public UsuarioService(LinkticEcommerceContext context, IMapper mapper, EncryptUtilities encrypt)
        {
            _context = context;
            _mapper = mapper;
            _encrypt = encrypt;
        }



        public async Task<ListarUsuarioDTO> CreateUsuarioAsync(CrearUsuarioDTO crearUsuarioDto)
        {

            

            var existingUsuario = await _context.Usuarios.FirstOrDefaultAsync(p => p.Correo == crearUsuarioDto.Correo);
            if (existingUsuario != null) throw new InvalidOperationException($"El correo ya está registrado");


            var usuario = _mapper.Map<Usuario>(crearUsuarioDto);
            usuario.Password = _encrypt.HashPassword(crearUsuarioDto.Password); // Encriptar la contraseña

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            var responseUsuario = _mapper.Map<ListarUsuarioDTO>(usuario);

            return responseUsuario;


        }
    }
}
