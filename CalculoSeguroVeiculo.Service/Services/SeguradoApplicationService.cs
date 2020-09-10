using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using CalculoSeguroVeiculo.Domain.Mappings;
using CalculoSeguroVeiculo.Infrastructure.UnitOfWork.Interfaces;
using CalculoSeguroVeiculo.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace CalculoSeguroVeiculo.Service.Services
{
    public class SeguradoApplicationService : ISeguradoApplicationService
    {
        private readonly ISeguradoUnitOfWork _unitOfWork;

        public SeguradoApplicationService(ISeguradoUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void InclusaoSegurado(SeguradoPostDto seguradoDto)
        {
            if (seguradoDto == null)
                throw new Exception("Não foi possível Inserir o Segurado");
            var segurado = Mapping.ToSegurado(seguradoDto);
            _unitOfWork.SeguradoRepository().Add(segurado);
        }

        public IEnumerable<SeguradoGetDto> GetAllDto()
        {
            var segurados = _unitOfWork.SeguradoRepository().GetAll();
            return Mapping.ToSeguradosGetDto(segurados);
        }

        public SeguradoGetDto GetByIdDto(int id)
        {
            var segurado = _unitOfWork.SeguradoRepository().GetById(id);
            if (segurado == null)
                throw new Exception("Não foi possível localizar o Segurado");
            return Mapping.ToSeguradoGetDto(segurado);
        }
    }
}