using TW.Trains.Domain.Models;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Domain.Services
{
    public class CalculadoraDistancias : ICalculadoraDistancias
    {
        private readonly Ferrovia ferrovia;

        public CalculadoraDistancias(Ferrovia ferrovia)
        {
            this.ferrovia = ferrovia;
        }

        public string CalcularDistanciaRotaEntreCidades(string[] cidades)
        {
            double distanciaTotal = 0;

            // Validacao para verificar se a primeira cidade existe
            if (!ferrovia.Rotas.ContainsKey(cidades[0]))
                return MensagensUtil.MensagemRotaNaoExiste;

            // Percorre-se todas as cidades verificando se a proxima cidade está conectada, em caso negativo encerra a busca
            for (int i = 0; i < cidades.Length - 1; i++)
            {
                var origem = ferrovia.Rotas[cidades[i]];
                var proximoDestino = cidades[i + 1];

                if (origem.ContainsKey(proximoDestino))
                {
                    var distanciaParaProximoDestino = origem[proximoDestino];
                    distanciaTotal += distanciaParaProximoDestino;
                }
                else
                    return MensagensUtil.MensagemRotaNaoExiste;
            }

            // Retorna a distancia para se percorrer as cidades
            return distanciaTotal.ToString();
        }
    }
}
