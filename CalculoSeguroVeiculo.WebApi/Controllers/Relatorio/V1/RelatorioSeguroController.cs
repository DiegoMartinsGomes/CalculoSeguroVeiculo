using CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V1;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoSeguroVeiculo.WebApi.Controllers.Relatorio.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RelatorioSeguroController : ControllerBase
    {
        private readonly ISeguroApplicationService _seguroApplicationService;

        public RelatorioSeguroController(ISeguroApplicationService seguroApplicationService)
        {
            _seguroApplicationService = seguroApplicationService; ;
        }

        [HttpGet]
        [ProducesResponseType(typeof(RelatorioSeguroV1GetDto), 200)]
        public IActionResult GetReport()
        {
            var seguros = _seguroApplicationService.GetAll();
            var segurosDto = _seguroApplicationService.EntitiesToDtos(seguros);

            var result = _seguroApplicationService.RelatorioV1(segurosDto);

            return Ok(result);
        }
    }
}
