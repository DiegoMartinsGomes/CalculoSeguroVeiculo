using CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V1;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoSeguroVeiculo.WebApi.Controllers.Relatorio.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly ISeguroApplicationService _seguroApplicationService;

        public RelatoriosController(ISeguroApplicationService seguroApplicationService)
        {
            _seguroApplicationService = seguroApplicationService; ;
        }

        [HttpGet]
        [ProducesResponseType(typeof(RelatorioSeguroV1GetDto), 200)]
        public IActionResult GetReport()
        {
            var seguros = _seguroApplicationService.GetAll();
            var segurosDto = _seguroApplicationService.EntitiesToDtos(seguros);

            var result = _seguroApplicationService.RelatorioV2(segurosDto);

            return Ok(result);
        }
    }
}
