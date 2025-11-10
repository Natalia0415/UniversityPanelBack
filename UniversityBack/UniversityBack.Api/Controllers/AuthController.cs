using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityBack.Application.Auth;
using UniversityBack.Application;
using UniversityBack.Business.Interfaces;

namespace UniversityBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (result.IsFailed)
            {
                return BadRequest(ApiResponse<AuthResponseDto>.Fail(result.Errors.First().Message));
            }
            return Ok(ApiResponse<AuthResponseDto>.Ok(result.Value, "Registro exitoso"));
        }
    }
}
