using System;
using CalculoSeguroVeiculo.Crosscutting.Enums;

namespace CalculoSeguroVeiculo.Crosscutting.RespostaApi.Interfaces
{
    public interface IResposta<T>
    {
        T Resultado { get; set; }
        Exception Exception { get; set; }
        string Mensagem { get; set; }
        StatusResposta Status { get; set; }
        string DescricaoStatus { get; }
    }
}
