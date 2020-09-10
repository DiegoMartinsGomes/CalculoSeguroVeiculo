using CalculoSeguroVeiculo.Crosscutting.Enums;
using System;

namespace CalculoSeguroVeiculo.Crosscutting.RespostaApi
{
    public static class RespostaErro
    {
        public static void Montar(Resposta resposta, Exception e)
        {
            resposta.Exception = e;
            resposta.Mensagem = e.Message;
            resposta.Status = StatusResposta.Erro;
        }
    }
}