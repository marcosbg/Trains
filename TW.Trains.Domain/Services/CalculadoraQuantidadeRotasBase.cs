using System;
using TW.Trains.Domain.Models;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Domain.Services
{
    public abstract class CalculadoraQuantidadeRotasBase : ICalculadoraQuantidadeRotas
    {
        protected Ferrovia Ferrovia { get; }
        protected int QuantidadeRotas { get; set; }

        protected CalculadoraQuantidadeRotasBase(Ferrovia ferrovia)
        {
            Ferrovia = ferrovia;
        }

        // Mét0do para controlar a chamada do mét0do recursivo e retornar o resultado
        public string CalcularQuantidadeRotas(string cidadeOrigem, string cidadeDestino, double numeroReferencia)
        {
            if (!Ferrovia.Rotas.ContainsKey(cidadeOrigem))
                return MensagensUtil.MensagemRotaNaoExiste;

            if (!Ferrovia.Rotas.ContainsKey(cidadeDestino))
                return MensagensUtil.MensagemRotaNaoExiste;

            QuantidadeRotas = 0;

            QuantidadeParadasComReferencia(cidadeOrigem, cidadeDestino, 0, numeroReferencia);

            return QuantidadeRotas.ToString();
        }

        protected abstract void QuantidadeParadasComReferencia(string cidadeOrigem, string cidadeDestino, double numeroAtual, double numeroReferencia);
    }
}
