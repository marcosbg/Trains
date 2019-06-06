using TW.Trains.Domain.Models;

namespace TW.Trains.Domain.Services
{
    public class CalculadoraQuantidadeRotasComNumeroExato : CalculadoraQuantidadeRotasBase
    {
        public CalculadoraQuantidadeRotasComNumeroExato(Ferrovia ferrovia) : base(ferrovia)
        {
        }

        protected override void QuantidadeParadasComReferencia(string cidadeOrigem, string cidadeDestino, double numeroAtual, double numeroReferencia)
        {
            // Busca nas cidades proximas a atual e verifica se chegou nos destino e a quantidade de paradas é igual ao esperado
            foreach (string cidadeBusca in Ferrovia.ObterCidade(cidadeOrigem).Vizinhos.Keys)
            {
                var qtdParadas = numeroAtual + 1;
                if (qtdParadas > numeroReferencia)
                    return;

                if (cidadeBusca == cidadeDestino && qtdParadas == numeroReferencia)
                {
                    QuantidadeRotas += 1;
                }
                else
                {
                    QuantidadeParadasComReferencia(cidadeBusca, cidadeDestino, qtdParadas, numeroReferencia);
                }
            }
        }
    }
}
