using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        private readonly ISeguroApplicationService _appService;

        public SeguroController(ISeguroApplicationService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Seguro), 200)]
        public ActionResult<Seguro> Post([FromBody] Seguro seguro)
        {
            _appService.Add(seguro);
            return Ok(seguro);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Seguro>), 200)]
        public IActionResult GetAll()
        {
            var result = _appService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Seguro), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _appService.GetById(id);
            return Ok(result);
        }
    }
}
