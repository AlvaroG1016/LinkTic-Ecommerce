using Dropi_Dev.Models.CustomResponses;
using Dropi_Dev.Utilities;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Implementations;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkTic_Ecommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }


        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> GetAllPedidos()
        {
            try
            {
                var data = await _pedidoService.GetAllPedidosAsync();
                return Ok(ResponseBuilder.BuildSuccessResponse(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBuilder.BuildErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> CreatePedido([FromBody] CrearPedidoDTO crearPedidoDTO)
        {
            try
            {
                var response = await _pedidoService.CreatePedidoAsync(crearPedidoDTO);
                return Ok(ResponseBuilder.BuildSuccessResponse(response, "Pedido creado exitosamente"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBuilder.BuildErrorResponse(ex.Message));

            }
        }

    }
}
