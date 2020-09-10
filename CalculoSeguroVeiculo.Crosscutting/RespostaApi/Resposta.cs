using System;
using CalculoSeguroVeiculo.Crosscutting.Enums;

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
    }
}
