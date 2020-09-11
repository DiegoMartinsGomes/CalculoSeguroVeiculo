using CalculoSeguroVeiculo.Crosscutting.Enums;
using System;

namespace CalculoSeguroVeiculo.Crosscutting.RespostaApi
{
    public static class MontarResposta
    {
        public static Resposta Sucesso(string mensagem = "")
        {
            return new Resposta()
            {
                Status = StatusResposta.Sucesso,
                Mensagem = mensagem
            };
        }

        public static Resposta<T> Sucesso<T>(T resultado, string mensagem = "")
        {
            return new Resposta<T>()
            {
                Status = StatusResposta.Sucesso,
                Resultado = resultado
            };
        }

        public static Resposta Erro(Exception exception, string mensagem = "")
        {
            return new Resposta()
            {
                Status = StatusResposta.Erro,
                Exception = exception,
                Mensagem = mensagem ?? exception.Message
            };
        }

        public static Resposta<T> Erro<T>(Exception exception, string mensagem = "")
        {
            return new Resposta<T>()
            {
                Status = StatusResposta.Erro,
                Exception = exception,
                Mensagem = mensagem ?? exception.Message
            };
        }
    }
}
