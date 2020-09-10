using CalculoSeguroVeiculo.Crosscutting.RespostaApi;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V1;
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
        [ProducesResponseType(typeof(Resposta<RelatorioSeguroV1GetDto>), 200)]
        public IActionResult GetReport()
        {
            var result = _seguroApplicationService.GerarRelatorioV2();
            return Ok(result);
        }
    }
}
