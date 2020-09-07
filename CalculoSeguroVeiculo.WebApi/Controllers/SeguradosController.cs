using CalculoSeguroVeiculo.Crosscutting.Dto.SeguradoDto;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SeguradosController : ControllerBase
    {
        private readonly ISeguradoApplicationService _seguradoApplicationService;

        public SeguradosController(ISeguradoApplicationService seguradoApplicationService)
        {
            _seguradoApplicationService = seguradoApplicationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SeguradoPostDto seguradoDto)
        {
            var segurado = _seguradoApplicationService.DtoToEntity(seguradoDto);
            _seguradoApplicationService.Add(segurado);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SeguradoGetDto>), 200)]
        public IActionResult GetAll()
        {
            var segurados = _seguradoApplicationService.GetAll();
            var result = _seguradoApplicationService.EntitiesToDtos(segurados);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SeguradoGetDto), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var segurado = _seguradoApplicationService.GetById(id);
            var result = _seguradoApplicationService.EntityToDto(segurado);

            return Ok(result);
        }
    }
}
