using CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class SeguroApplicationService : ApplicationService<Seguro>, ISeguroApplicationService
    {
        private readonly ISeguroRepository _seguroRepository;
        private readonly ISeguradoApplicationService _seguradoApplicationService;
        private readonly IVeiculoApplicationService _veiculoApplicationService;

        public SeguroApplicationService(
            ISeguroRepository seguroRepository,
            ISeguradoApplicationService seguradoApplicationService,
            IVeiculoApplicationService veiculoApplicationService) : base(seguroRepository)
        {
            _seguroRepository = seguroRepository;
            _seguradoApplicationService = seguradoApplicationService;
            _veiculoApplicationService = veiculoApplicationService;
        }

        public void InclusaoSeguro(SeguroPostDto seguroDto)
        {
            //TODO
            var valorSeguro = 1000;

            var seguro = new Seguro()
            {
                IdSegurado = seguroDto.IdSegurado,
                IdVeiculo = seguroDto.IdVeiculo,
                DataCalculo = DateTime.Now,
                ValorSeguro = valorSeguro,
            };

            Add(seguro);
        }

        public SeguroGetDto EntityToDto(Seguro seguro)
        {
            var segurado = _seguradoApplicationService.EntityToDto(_seguradoApplicationService.GetById(seguro.IdSegurado));
            var veiculo = _veiculoApplicationService.EntityToDto(_veiculoApplicationService.GetById(seguro.IdVeiculo));

            return new SeguroGetDto()
            {
                Id = seguro.Id,
                IdSegurado = seguro.IdSegurado,
                IdVeiculo = seguro.IdVeiculo,
                DataCalculo = seguro.DataCalculo,
                ValorSeguro = seguro.ValorSeguro,
                Segurado = segurado,
                Veiculo = veiculo,
            };
        }

        public IEnumerable<SeguroGetDto> EntitiesToDtos(IEnumerable<Seguro> seguros)
        {
            return seguros.Select(x => new SeguroGetDto()
            {
                Id = x.Id,
                IdSegurado = x.IdSegurado,
                IdVeiculo = x.IdVeiculo,
                DataCalculo = x.DataCalculo,
                ValorSeguro = x.ValorSeguro,
                Segurado = _seguradoApplicationService.EntityToDto(_seguradoApplicationService.GetById(x.IdSegurado)),
                Veiculo = _veiculoApplicationService.EntityToDto(_veiculoApplicationService.GetById(x.IdVeiculo))
            });
        }
    }
}
