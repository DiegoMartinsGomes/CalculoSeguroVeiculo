using CalculoSeguroVeiculo.Crosscutting.Enums;
using CalculoSeguroVeiculo.Crosscutting.Helpers;
using System;

namespace CalculoSeguroVeiculo.Crosscutting.RespostaApi
{
    public class Resposta
    {
        public Resposta()
        {
            Status = StatusResposta.Sucesso;
        }

        public StatusResposta Status { get; set; }
        public string Mensagem { get; set; }
        public Exception Exception { get; set; }
        public string DescricaoStatus
        {
            get
            {
                return EnumHelper.GetDescription<StatusResposta>(Status);
            }
        }
    }
}
