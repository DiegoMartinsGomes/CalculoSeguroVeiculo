using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguradoController : ControllerBase
    {
        private readonly ISeguradoApplicationService _appService;

        public SeguradoController(ISeguradoApplicationService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Segurado), 200)]
        public ActionResult<Segurado> Post([FromBody] Segurado segurado)
        {
            _appService.Add(segurado);
            return Ok(segurado);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Segurado>), 200)]
        public IActionResult GetAll()
        {
            var result = _appService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Segurado), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _appService.GetById(id);
            return Ok(result);
        }
    }
}
