using Dropi_Dev.Models.CustomResponses;
using Dropi_Dev.Utilities;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkTic_Ecommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> CreateUsuarioAsync([FromBody] CrearUsuarioDTO crearUsuarioDTO)
        {
            try
            {
                var response = await _usuarioService.CreateUsuarioAsync(crearUsuarioDTO);
                return Ok(ResponseBuilder.BuildSuccessResponse(response, "Usuario creado exitosamente"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBuilder.BuildErrorResponse(ex.Message));
            }
        }
    }
}
