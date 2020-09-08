using CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V1;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoSeguroVeiculo.WebApi.Controllers.Relatorio.V1
{
    [ApiVersion("1.0")]
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
            var result = _seguroApplicationService.GerarRelatorioV1();

            return Ok(result);
        }
    }
}
