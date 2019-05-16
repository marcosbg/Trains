using System.Collections.Generic;

namespace TW.Trains.Domain.Models
{
    public class Ferrovia
    {
        public Dictionary<string, Dictionary<string, double>> Rotas { get; private set; }

        public Ferrovia()
        {
            Rotas = new Dictionary<string, Dictionary<string, double>>();
        }

        // Adiciona as rotas modeladas em forma de grafo usando hashtable. 
        public void AdicionarRota(string origem, string destino, double distancia)
        {
            if (!Rotas.ContainsKey(origem))
                Rotas[origem] = new Dictionary<string, double>();

            if (!Rotas.ContainsKey(destino))
                Rotas[destino] = new Dictionary<string, double>();

            Rotas[origem][destino] = distancia;
        }
    }
}
