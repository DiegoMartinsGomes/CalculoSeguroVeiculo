using CalculoSeguroVeiculo.Crosscutting.Dto.VeiculoDto;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoApplicationService _veiculoApplicationService;

        public VeiculoController(IVeiculoApplicationService veiculoApplicationService)
        {
            _veiculoApplicationService = veiculoApplicationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoPostDto veiculoDto)
        {
            var veiculo = _veiculoApplicationService.DtoToEntity(veiculoDto);
            _veiculoApplicationService.Add(veiculo);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VeiculoGetDto>), 200)]
        public IActionResult GetAll()
        {
            var veiculos = _veiculoApplicationService.GetAll();
            var result = _veiculoApplicationService.EntitiesToDtos(veiculos);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(VeiculoGetDto), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var veiculo = _veiculoApplicationService.GetById(id);
            var result = _veiculoApplicationService.EntityToDto(veiculo);

            return Ok(result);
        }
    }
}
