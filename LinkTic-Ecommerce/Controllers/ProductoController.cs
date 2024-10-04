using Dropi_Dev.Models.CustomResponses;
using Dropi_Dev.Utilities;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkTic_Ecommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> GetAllProductos()
        {
            try
            {
                var data = await _productoService.GetAllProductos();
                return Ok(ResponseBuilder.BuildSuccessResponse(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBuilder.BuildErrorResponse(ex.Message));
            }
        }
        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> CreateProducto([FromBody] CrearProductoDTO crearProductoDTO)
        {
            try
            {
                var response = await _productoService.CreateProductoAsync(crearProductoDTO);
                return Ok(ResponseBuilder.BuildSuccessResponse(response, "Producto creado exitosamente"));
            }
            catch (Exception ex) 
            {
                return BadRequest(ResponseBuilder.BuildErrorResponse(ex.Message));

            }

        }
    }
}
