using CalculoSeguroVeiculo.Crosscutting.RespostaApi;
using CalculoSeguroVeiculo.DataTransferObject.VeiculoDto;
using CalculoSeguroVeiculo.Domain.Mappings;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class VeiculoApplicationService : IVeiculoApplicationService
    {
        private readonly IVeiculoUnitOfWork _unitOfWork;

        public VeiculoApplicationService(IVeiculoUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Resposta InclusaoVeiculo(VeiculoPostDto veiculoDto)
        {
            try
            {
                var veiculo = Mapping.ToVeiculo(veiculoDto);
                _unitOfWork.VeiculoRepository().Add(veiculo);
                return MontarResposta.Sucesso();
            }
            catch (Exception e)
            {
                return MontarResposta.Erro(e);
            }
        }

        public Resposta<IEnumerable<VeiculoGetDto>> GetAllDto()
        {
            try
            {
                var veiculos = _unitOfWork.VeiculoRepository().GetAll();
                var dto = Mapping.ToVeiculosGetDto(veiculos);
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<IEnumerable<VeiculoGetDto>>(e);
            }
        }

        public Resposta<VeiculoGetDto> GetByIdDto(int id)
        {
            try
            {
                var veiculo = _unitOfWork.VeiculoRepository().GetById(id);
                var dto = Mapping.ToVeiculoGetDto(veiculo);
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<VeiculoGetDto>(e);
            }
        }
    }
}