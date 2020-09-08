using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
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
            _seguradoApplicationService.InclusaoSegurado(seguradoDto);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SeguradoGetDto>), 200)]
        public IActionResult GetAll()
        {
            var result = _seguradoApplicationService.GetAllDto();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SeguradoGetDto), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _seguradoApplicationService.GetByIdDto(id);
            return Ok(result);
        }
    }
}
