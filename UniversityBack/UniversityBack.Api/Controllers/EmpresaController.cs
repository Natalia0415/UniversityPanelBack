using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityBack.Application;
using UniversityBack.Business.Interfaces;
using UniversityBack.Domain.Entities;

namespace UniversityBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IBaseService<Empresa, EmpresaDto> _baseService;
        //private readonly ICustomerService _customerService;
        public EmpresaController(IBaseService<Empresa, EmpresaDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpresaDto empresaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Result<Empresa> result = await _baseService.CreateAsync(empresaDto);
            return Ok(ApiResponse<Empresa>.Ok(result.Value, "Actualizado correctamente"));
        }
    }
}
