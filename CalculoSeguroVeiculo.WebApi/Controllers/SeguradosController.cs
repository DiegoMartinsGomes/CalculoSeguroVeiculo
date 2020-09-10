using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CalculoSeguroVeiculo.Crosscutting.RespostaApi;

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
        [ProducesResponseType(typeof(Resposta), 200)]
        public IActionResult Post([FromBody] SeguradoPostDto seguradoDto)
        {
            var result = _seguradoApplicationService.InclusaoSegurado(seguradoDto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Resposta<IEnumerable<SeguradoGetDto>>), 200)]
        public IActionResult GetAll()
        {
            var result = _seguradoApplicationService.GetAllDto();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Resposta<SeguradoGetDto>), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _seguradoApplicationService.GetByIdDto(id);
            return Ok(result);
        }
    }
}
