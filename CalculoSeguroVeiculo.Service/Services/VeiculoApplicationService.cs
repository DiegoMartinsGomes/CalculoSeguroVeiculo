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

        public void InclusaoVeiculo(VeiculoPostDto veiculoDto)
        {
            if (veiculoDto == null)
                throw new Exception("Não foi possível inserir o Veiculo.");
            var veiculo = Mapping.ToVeiculo(veiculoDto);
            _unitOfWork.VeiculoRepository().Add(veiculo);
        }

        public IEnumerable<VeiculoGetDto> GetAllDto()
        {
            var veiculos = _unitOfWork.VeiculoRepository().GetAll();
            return Mapping.ToVeiculosGetDto(veiculos);
        }

        public VeiculoGetDto GetByIdDto(int id)
        {
            var veiculo = _unitOfWork.VeiculoRepository().GetById(id);
            return Mapping.ToVeiculoGetDto(veiculo);
        }
    }
}