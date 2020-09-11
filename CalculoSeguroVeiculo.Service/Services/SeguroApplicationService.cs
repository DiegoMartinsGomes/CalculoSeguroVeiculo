using CalculoSeguroVeiculo.Crosscutting.Estatico;
using CalculoSeguroVeiculo.Crosscutting.RespostaApi;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V1;
using CalculoSeguroVeiculo.DataTransferObject.Relatorio.V2;
using CalculoSeguroVeiculo.DataTransferObject.SeguroDto;
using CalculoSeguroVeiculo.Domain.Mappings;
using CalculoSeguroVeiculo.Domain.Models;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class SeguroApplicationService : ISeguroApplicationService
    {
        private readonly ISeguroUnitOfWork _unitOfWork;

        public SeguroApplicationService(ISeguroUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Resposta InclusaoSeguro(SeguroPostDto seguroDto)
        {
            try
            {
                var veiculo = _unitOfWork.VeiculoRepository().GetById(seguroDto.IdVeiculo);
                var valorSeguro = CalculoSeguroVeiculo(veiculo);
                var seguro = new Seguro()
                {
                    IdSegurado = seguroDto.IdSegurado,
                    IdVeiculo = seguroDto.IdVeiculo,
                    DataCalculo = DateTime.Now,
                    Valor = valorSeguro,
                };
                _unitOfWork.SeguroRepository().Add(seguro);
                return MontarResposta.Sucesso();
            }
            catch (Exception e)
            {
                return MontarResposta.Erro(e);
            }
        }

        public Resposta<RelatorioSeguroV1GetDto> GerarRelatorioV1()
        {
            try
            {
                var seguros = GetAllRelacionado();
                var media = seguros.Average(x => x.Valor);
                var dto = new RelatorioSeguroV1GetDto()
                {
                    Media = media
                };
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<RelatorioSeguroV1GetDto>(e);
            }
        }

        public Resposta<RelatorioSeguroV2GetDto> GerarRelatorioV2()
        {
            try
            {
                var seguros = GetAllRelacionado();
                var media = seguros.Average(x => x.Valor);
                var dto = new RelatorioSeguroV2GetDto()
                {
                    Seguros = Mapping.ToSegurosGetDto(seguros),
                    Mensagem = $"A média aritimética dos Seguros é de: {media}.",
                    Media = media
                };
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<RelatorioSeguroV2GetDto>(e);
            }
        }

        public Resposta<IEnumerable<SeguroGetDto>> GetAllDto()
        {
            try
            {
                var seguros = GetAllRelacionado();
                var dto = Mapping.ToSegurosGetDto(seguros);
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<IEnumerable<SeguroGetDto>>(e);
            }
        }

        public Resposta<SeguroGetDto> GetByIdDto(int id)
        {
            try
            {
                var seguro = _unitOfWork.SeguroRepository().GetAll()
                    .Where(x => x.Id == id)
                    .Select(x => new Seguro()
                    {
                        Id = x.Id,
                        IdSegurado = x.IdSegurado,
                        IdVeiculo = x.IdVeiculo,
                        DataCalculo = x.DataCalculo,
                        Valor = x.Valor,
                        Segurado = x.Segurado,
                        Veiculo = x.Veiculo
                    }).FirstOrDefault();
                var dto = Mapping.ToSeguroGetDto(seguro, seguro.Segurado, seguro.Veiculo);
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<SeguroGetDto>(e);
            }
        }

        private IEnumerable<Seguro> GetAllRelacionado()
        {
            var seguros = _unitOfWork.SeguroRepository().GetAll()
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

        private decimal CalculoSeguroVeiculo(Veiculo veiculo)
        {
            if (veiculo == null)
                throw new Exception("Não foi possível Calcular o Seguro.");

            var valorVeiculo = Convert.ToDouble(veiculo.Valor);
            var taxaRisco = ((valorVeiculo * TaxaCalculo.ValorCinco) / (TaxaCalculo.ValorDois * valorVeiculo));
            var premioRisco = (taxaRisco * valorVeiculo);
            var premioPuro = (premioRisco * (TaxaCalculo.ValorUm + PercentualCalculo.MargemSeguranca));
            var premioComercial = (PercentualCalculo.Lucro * premioPuro);
            var valorSeguro = Convert.ToDecimal(Math.Round(((premioComercial + premioPuro) / 100), 2, MidpointRounding.ToZero));
            return valorSeguro;
        }
    }
}
