using Dropi_Dev.Models.CustomResponses;
using Dropi_Dev.Utilities;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkTic_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> Login(LoginDTO loginDTO)
        {
            try
            {
                var response = await _authService.Login(loginDTO);
                return Ok(ResponseBuilder.BuildSuccessResponse(response, ""));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBuilder.BuildErrorResponse(ex.Message));

            }
        }
    }
}
