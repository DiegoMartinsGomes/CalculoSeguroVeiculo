using CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V1;
using CalculoSeguroVeiculo.Crosscutting.Dto.Relatorio.V2;
using CalculoSeguroVeiculo.Crosscutting.Dto.SeguroDto;
using CalculoSeguroVeiculo.Crosscutting.Estatico;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.Repository.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var veiculo = _veiculoApplicationService.GetById(seguroDto.IdVeiculo);
            var valorSeguro = CalculoSeguroVeiculo(veiculo);

            var seguro = new Seguro()
            {
                IdSegurado = seguroDto.IdSegurado,
                IdVeiculo = seguroDto.IdVeiculo,
                DataCalculo = DateTime.Now,
                Valor = valorSeguro,
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
                Valor = seguro.Valor,
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
                Valor = x.Valor,
                Segurado = _seguradoApplicationService.EntityToDto(_seguradoApplicationService.GetById(x.IdSegurado)),
                Veiculo = _veiculoApplicationService.EntityToDto(_veiculoApplicationService.GetById(x.IdVeiculo))
            });
        }

        public decimal CalculoSeguroVeiculo(Veiculo veiculo)
        {
            var valorVeiculo = Convert.ToDouble(veiculo.Valor);
            var taxaRisco = ((valorVeiculo * 5) / (2 * valorVeiculo));
            var premioRisco = (taxaRisco * valorVeiculo);
            var premioPuro = (premioRisco * (1 + PercentualCalculo.MargemSeguranca));
            var premioComercial = (PercentualCalculo.Lucro * premioPuro);

            var valorSeguro = Convert.ToDecimal(Math.Round(((premioComercial + premioPuro) / 100), 2, MidpointRounding.ToZero));

            return valorSeguro;
        }

        public RelatorioSeguroV1GetDto RelatorioV1(IEnumerable<SeguroGetDto> seguros)
        {
            var media = seguros.Average(x => x.Valor);

            return new RelatorioSeguroV1GetDto()
            {
                Media = media
            };
        }

        public RelatorioSeguroV2GetDto RelatorioV2(IEnumerable<SeguroGetDto> seguros)
        {
            var media = seguros.Average(x => x.Valor);

            return new RelatorioSeguroV2GetDto()
            {
                Seguros = seguros,
                Mensagem = $"A média aritimética dos Seguros é de: {media}.",
                Media = media
            };
        }
    }
}
