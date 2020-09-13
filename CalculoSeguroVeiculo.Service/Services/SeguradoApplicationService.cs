using CalculoSeguroVeiculo.Crosscutting.RespostaApi;
using CalculoSeguroVeiculo.DataTransferObject.SeguradoDto;
using CalculoSeguroVeiculo.Infrastructure.Mappings;
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

        public Resposta InclusaoSegurado(SeguradoPostDto seguradoDto)
        {
            try
            {
                var segurado = Mapping.ToSegurado(seguradoDto);
                _unitOfWork.SeguradoRepository().Add(segurado);
                return MontarResposta.Sucesso();
            }
            catch (Exception e)
            {
                return MontarResposta.Erro(e);
            }
        }

        public Resposta<IEnumerable<SeguradoGetDto>> GetAllDto()
        {
            try
            {
                var segurados = _unitOfWork.SeguradoRepository().GetAll();
                var dto = Mapping.ToSeguradosGetDto(segurados);
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<IEnumerable<SeguradoGetDto>>(e);
            }
        }

        public Resposta<SeguradoGetDto> GetByIdDto(int id)
        {
            try
            {
                var segurado = _unitOfWork.SeguradoRepository().GetById(id);
                var dto = Mapping.ToSeguradoGetDto(segurado);
                return MontarResposta.Sucesso(dto);
            }
            catch (Exception e)
            {
                return MontarResposta.Erro<SeguradoGetDto>(e);
            }
        }
    }
}
