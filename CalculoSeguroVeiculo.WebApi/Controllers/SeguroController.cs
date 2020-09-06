﻿using CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto;
using CalculoSeguroVeiculo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        private readonly ISeguroApplicationService _seguroApplicationService;

        public SeguroController(ISeguroApplicationService seguroApplicationService)
        {
            _seguroApplicationService = seguroApplicationService; ;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SeguroPostDto seguro)
        {
            _seguroApplicationService.InclusaoSeguro(seguro);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SeguroGetDto>), 200)]
        public IActionResult GetAll()
        {
            var seguros = _seguroApplicationService.GetAll();
            var result = _seguroApplicationService.EntitiesToDtos(seguros);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SeguroGetDto), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            var seguro = _seguroApplicationService.GetById(id);
            var result = _seguroApplicationService.EntityToDto(seguro);

            return Ok(result);
        }
    }
}
