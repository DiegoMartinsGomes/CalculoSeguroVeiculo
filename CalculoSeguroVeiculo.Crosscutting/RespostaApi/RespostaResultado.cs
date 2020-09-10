using CalculoSeguroVeiculo.Crosscutting.Enums;

namespace CalculoSeguroVeiculo.Crosscutting.RespostaApi
{
    public class Resposta<T> : Resposta
    {
        public T Resultado { get; set; }
    }
}
