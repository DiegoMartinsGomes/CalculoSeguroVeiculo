using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoApplicationService _veiculoApplicationService;

        public VeiculosController(IVeiculoApplicationService veiculoApplicationService)
        {
            _veiculoApplicationService = veiculoApplicationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoPostDto veiculoDto)
        {
            _veiculoApplicationService.InclusaoVeiculo(veiculoDto);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VeiculoGetDto>), 200)]
        public IActionResult GetAll()
        {
            var result = _veiculoApplicationService.GetAllDto();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(VeiculoGetDto), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _veiculoApplicationService.GetByIdDto(id);
            return Ok(result);
        }
    }
}
