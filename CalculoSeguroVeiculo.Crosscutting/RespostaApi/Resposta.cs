using CalculoSeguroVeiculo.Crosscutting.Enums;
using CalculoSeguroVeiculo.Crosscutting.Helpers;
using System;
using CalculoSeguroVeiculo.Crosscutting.RespostaApi.Interfaces;

namespace CalculoSeguroVeiculo.Crosscutting.RespostaApi
{
    public class Resposta<T> : IResposta<T>
    {
        public T Resultado { get; set; }
        public Exception Exception { get; set; }
        public string Mensagem { get; set; }
        public StatusResposta Status { get; set; }
        public string DescricaoStatus
        {
            get
            {
                return EnumHelper.GetDescription<StatusResposta>(Status);
            }
        }
    }

    public class Resposta
    {
        public Exception Exception { get; set; }
        public string Mensagem { get; set; }
        public StatusResposta Status { get; set; }
        public string DescricaoStatus
        {
            get
            {
                return EnumHelper.GetDescription<StatusResposta>(Status);
            }
        }
    }
}
