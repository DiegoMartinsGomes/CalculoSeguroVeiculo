using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoApplicationService _appService;

        public VeiculoController(IVeiculoApplicationService appService)
        {
            _appService = appService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Veiculo), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _appService.GetById(id);
            return Ok(result);
        }
    }
}
