using System;
using System.Collections;
using System.Collections.Generic;
using TW.Trains.Domain.Models;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Domain.Services
{
    public class CalculadoraMenoresDistancias : ICalculadoraMenoresDistancias
    {
        private readonly Ferrovia ferrovia;
        private IList<string> cidadesProcessadas = new List<string>();

        public CalculadoraMenoresDistancias(Ferrovia ferrovia)
        {
            this.ferrovia = ferrovia;
        }

        // Met0do baseado no algoritmo de Dijkistra
        public string CalcularDistanciaDaMenorRotaParaViajar(string cidadeOrigem, string cidadeDestino)
        {
            if (!ferrovia.Rotas.ContainsKey(cidadeOrigem))
                return MensagensUtil.MensagemRotaNaoExiste;

            if (!ferrovia.Rotas.ContainsKey(cidadeDestino))
                return MensagensUtil.MensagemRotaNaoExiste;

            // Limpa-se as varias veis usadas para calcular a rota
            var distancias = new Hashtable();
            var pais = new Hashtable();
            cidadesProcessadas = new List<string>();

            // Cria as estruturas auxiliares de chave e valor com as cidades do grafo
            foreach (string c in ferrovia.Rotas.Keys)
            {
                distancias[c] = double.PositiveInfinity;
                pais[c] = null;
            }

            // Populando os valores conhecidos de distancia e hieraquia das rotas
            foreach (string c in (ferrovia.Rotas[cidadeOrigem] as Hashtable).Keys)
            {
                distancias[c] = (double)(ferrovia.Rotas[cidadeOrigem] as Hashtable)[c];
                pais[c] = cidadeOrigem;
            }

            // Escolhe a cidade com menor distancia para compor a rota
            var cidade = AcharCidadeMaisProxima(distancias);

            while (cidade != null)
            {
                var distancia = (double)distancias[cidade];

                // Verifica nas cidades proximas se é possível chegar em uma cidade mais de forma mais rápida
                var cidadesProximas = ferrovia.Rotas[cidade] as Hashtable;
                foreach (string c in cidadesProximas.Keys)
                {
                    var novaDistancia = distancia + (double)cidadesProximas[c];

                    if ((double)distancias[c] > novaDistancia)
                    {
                        distancias[c] = novaDistancia;
                        pais[c] = cidade;
                    }
                }

                // Marca a cidade para nao ser processada novamente
                cidadesProcessadas.Add(cidade);

                cidade = AcharCidadeMaisProxima(distancias);
            }

            return distancias[cidadeDestino].ToString();
        }

        // Met0do auxiliar para buscar a cidade com menor distancia para completar a rota
        private string AcharCidadeMaisProxima(Hashtable distancias)
        {
            double menorDistancia = double.PositiveInfinity;
            string cidadeMenorDistancia = null;

            // Para cada distancia mapeada verifica a cidade já foi processada e se a distancia é a menor que se pode escolher
            foreach (string cidade in distancias.Keys)
            {
                var distancia = (double)distancias[cidade];

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
