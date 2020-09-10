using CalculoSeguroVeiculo.Crosscutting.RespostaApi;
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

        public Resposta InclusaoSegurado(SeguradoPostDto seguradoDto)
        {
            var resposta = new Resposta();
            try
            {
                var segurado = Mapping.ToSegurado(seguradoDto);
                _unitOfWork.SeguradoRepository().Add(segurado);
            }
            catch (Exception e)
            {
                RespostaErro.Montar(resposta, e);
            }
            return resposta;
        }

        public Resposta<IEnumerable<SeguradoGetDto>> GetAllDto()
        {
            var resposta = new Resposta<IEnumerable<SeguradoGetDto>>();
            try
            {
                var segurados = _unitOfWork.SeguradoRepository().GetAll();
                resposta.Resultado = Mapping.ToSeguradosGetDto(segurados);
            }
            catch (Exception e)
            {
                RespostaErro.Montar(resposta, e);
            }
            return resposta;
        }

        public Resposta<SeguradoGetDto> GetByIdDto(int id)
        {
            var resposta = new Resposta<SeguradoGetDto>();
            try
            {
                var segurado = _unitOfWork.SeguradoRepository().GetById(id);
                resposta.Resultado = Mapping.ToSeguradoGetDto(segurado);
            }
            catch (Exception e)
            {
                RespostaErro.Montar(resposta, e);
            }
            return resposta;
        }
    }
}
