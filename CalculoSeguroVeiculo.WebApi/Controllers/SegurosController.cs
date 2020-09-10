using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CalculoSeguroVeiculo.Crosscutting.RespostaApi;

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly ISeguroApplicationService _seguroApplicationService;

        public SegurosController(ISeguroApplicationService seguroApplicationService)
        {
            _seguroApplicationService = seguroApplicationService; ;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Resposta), 200)]
        public IActionResult Post([FromBody] SeguroPostDto seguro)
        {
            var result = _seguroApplicationService.InclusaoSeguro(seguro);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Resposta<IEnumerable<SeguroGetDto>>), 200)]
        public IActionResult GetAll()
        {
            var result = _seguroApplicationService.GetAllDto();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Resposta<SeguroPostDto>), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _seguroApplicationService.GetByIdDto(id);
            return Ok(result);
        }
    }
}
