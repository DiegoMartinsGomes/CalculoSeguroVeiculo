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
            var resposta = new Resposta();
            try
            {
                var veiculo = Mapping.ToVeiculo(veiculoDto);
                _unitOfWork.VeiculoRepository().Add(veiculo);
            }
            catch (Exception e)
            {
                RespostaErro.Montar(resposta, e);
            }
            return resposta;
        }

        public Resposta<IEnumerable<VeiculoGetDto>> GetAllDto()
        {
            var resposta = new Resposta<IEnumerable<VeiculoGetDto>>();
            try
            {
                var veiculos = _unitOfWork.VeiculoRepository().GetAll();
                resposta.Resultado = Mapping.ToVeiculosGetDto(veiculos);
            }
            catch (Exception e)
            {
                RespostaErro.Montar(resposta, e);
            }
            return resposta;
        }

        public Resposta<VeiculoGetDto> GetByIdDto(int id)
        {
            var resposta = new Resposta<VeiculoGetDto>();
            try
            {
                var veiculo = _unitOfWork.VeiculoRepository().GetById(id);
                resposta.Resultado = Mapping.ToVeiculoGetDto(veiculo);
            }
            catch (Exception e)
            {
                RespostaErro.Montar(resposta, e);
            }
            return resposta;
        }
    }
}