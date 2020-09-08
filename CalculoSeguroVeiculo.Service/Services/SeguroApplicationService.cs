using CalculoSeguroVeiculo.Crosscutting.Estatico;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V1;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V2;
using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using CalculoSeguroVeiculo.Domain.Mappings;
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

        public decimal CalculoSeguroVeiculo(Veiculo veiculo)
        {
            var valorVeiculo = Convert.ToDouble(veiculo.Valor);
            var taxaRisco = ((valorVeiculo * TaxaCalculo.ValorCinco) / (TaxaCalculo.ValorDois * valorVeiculo));
            var premioRisco = (taxaRisco * valorVeiculo);
            var premioPuro = (premioRisco * (TaxaCalculo.ValorUm + PercentualCalculo.MargemSeguranca));
            var premioComercial = (PercentualCalculo.Lucro * premioPuro);
            var valorSeguro = Convert.ToDecimal(Math.Round(((premioComercial + premioPuro) / 100), 2, MidpointRounding.ToZero));
            return valorSeguro;
        }

        public RelatorioSeguroV1GetDto GerarRelatorioV1()
        {
            var seguros = GetAllRelacionado();
            var media = seguros.Average(x => x.Valor);
            return new RelatorioSeguroV1GetDto()
            {
                Media = media
            };
        }

        public RelatorioSeguroV2GetDto GerarRelatorioV2()
        {
            var seguros = GetAllRelacionado();
            var media = seguros.Average(x => x.Valor);
            return new RelatorioSeguroV2GetDto()
            {
                Seguros = Mapping.ToSegurosGetDto(seguros),
                Mensagem = $"A média aritimética dos Seguros é de: {media}.",
                Media = media
            };
        }

        public IEnumerable<SeguroGetDto> GetAllDto()
        {
            var seguros = GetAllRelacionado();
            return Mapping.ToSegurosGetDto(seguros);
        }

        public SeguroGetDto GetByIdDto(int id)
        {
            var seguro = GetById(id);
            var segurado = _seguradoApplicationService.GetById(seguro.IdSegurado);
            var veiculo = _veiculoApplicationService.GetById(seguro.IdVeiculo);
            return Mapping.ToSeguroGetDto(seguro, segurado, veiculo);
        }

        public IEnumerable<Seguro> GetAllRelacionado()
        {
            var seguros = _seguroRepository.GetAll()
                .Select(x => new Seguro()
                {
                    Id = x.Id,
                    IdSegurado = x.IdSegurado,
                    IdVeiculo = x.IdVeiculo,
                    DataCalculo = x.DataCalculo,
                    Valor = x.Valor,
                    Segurado = x.Segurado,
                    Veiculo = x.Veiculo
                });
            return seguros;
        }
    }
}
