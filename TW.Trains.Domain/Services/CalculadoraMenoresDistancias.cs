using System.Collections.Generic;
using TW.Trains.Domain.Models;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Domain.Services
{
    public class CalculadoraMenoresDistancias : ICalculadoraMenoresDistancias
    {
        private readonly Ferrovia ferrovia;
        private Dictionary<string, double> distancias;
        private Dictionary<string, string> pais;
        private IList<string> cidadesProcessadas;

        public CalculadoraMenoresDistancias(Ferrovia ferrovia)
        {
            this.ferrovia = ferrovia;
        }

        private void IniciarProriedadesParaCalculo()
        {
            // Limpa-se as varias veis usadas para calcular a rota
            distancias = new Dictionary<string, double>();
            pais = new Dictionary<string, string>();
            cidadesProcessadas = new List<string>();

            // Cria as estruturas auxiliares de chave e valor com as cidades do grafo
            foreach (string nomeCidade in ferrovia.Cidades.Keys)
            {
                distancias[nomeCidade] = double.PositiveInfinity;
                pais[nomeCidade] = null;
            }
        }

        private void PopularDistanciasConhecidadas(string cidadeOrigem)
        {
            // Populando os valores conhecidos de distancia e hieraquia das rotas
            foreach (string vizinho in ferrovia.ObterCidade(cidadeOrigem).Vizinhos.Keys)
            {
                distancias[vizinho] = ferrovia.ObterCidade(cidadeOrigem).ObterRota(vizinho).Distancia;
                pais[vizinho] = cidadeOrigem;
            }
        }

        // Met0do baseado no algoritmo de Dijkistra
        public string CalcularDistanciaDaMenorRotaParaViajar(string cidadeOrigem, string cidadeDestino)
        {
            if (!ferrovia.CidadeExiste(cidadeOrigem))
                return MensagensUtil.MensagemRotaNaoExiste;

            if (!ferrovia.CidadeExiste(cidadeDestino))
                return MensagensUtil.MensagemRotaNaoExiste;

            IniciarProriedadesParaCalculo();

            PopularDistanciasConhecidadas(cidadeOrigem);

            // Escolhe a cidade com menor distancia para compor a rota
            var cidade = AcharCidadeMaisProxima();

            while (cidade != null)
            {
                var distancia = distancias[cidade];

                // Verifica nas cidades proximas se é possível chegar em uma cidade mais de forma mais rápida
                var cidadesVizinhas = ferrovia.ObterCidade(cidade).Vizinhos;
                foreach (string c in cidadesVizinhas.Keys)
                {
                    var novaDistancia = distancia + cidadesVizinhas[c].Distancia;

                    if (distancias[c] > novaDistancia)
                    {
                        distancias[c] = novaDistancia;
                        pais[c] = cidade;
                    }
                }

                // Marca a cidade para nao ser processada novamente
                cidadesProcessadas.Add(cidade);

                cidade = AcharCidadeMaisProxima();
            }

            return distancias[cidadeDestino].ToString();
        }

        // Met0do auxiliar para buscar a cidade com menor distancia para completar a rota
        private string AcharCidadeMaisProxima()
        {
            double menorDistancia = double.PositiveInfinity;
            string cidadeMenorDistancia = null;

            // Para cada distancia mapeada verifica a cidade já foi processada e se a distancia é a menor que se pode escolher
            foreach (string cidade in distancias.Keys)
            {
                var distancia = distancias[cidade];

                if (distancia < menorDistancia && !cidadesProcessadas.Contains(cidade))
                {
                    menorDistancia = distancia;
                    cidadeMenorDistancia = cidade;
                }
            }

            // Retorna a cidade com menor distancia ou null quando nao encontra cidade melhor
            return cidadeMenorDistancia;
        }
    }
}
