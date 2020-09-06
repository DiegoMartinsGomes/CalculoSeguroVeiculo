﻿using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpPost]
        [ProducesResponseType(typeof(Veiculo), 200)]
        public ActionResult<Veiculo> Post([FromBody] Veiculo veiculo)
        {
            _appService.Add(veiculo);
            return Ok(veiculo);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Veiculo>), 200)]
        public IActionResult GetAll()
        {
            var result = _appService.GetAll();
            return Ok(result);
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
