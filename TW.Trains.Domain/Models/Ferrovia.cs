using System;
using System.Collections;
using System.Collections.Generic;

namespace TW.Trains.Domain.Models
{
    public class Ferrovia
    {
        public Hashtable Rotas { get; private set; } = new Hashtable();

        // Adiciona as rotas modeladas em forma de grafo usando hashtable. 
        public void AdicionarRota(string origem, string destino, double distancia)
        {
            if (!Rotas.ContainsKey(origem))
                Rotas[origem] = new Hashtable();

            if (!Rotas.ContainsKey(destino))
                Rotas[destino] = new Hashtable();

            (Rotas[origem] as Hashtable)[destino] = distancia;
        }
    }
}
