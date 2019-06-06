using System.Collections.Generic;

namespace TW.Trains.Domain.Models
{
    public class Ferrovia
    {
        public Dictionary<string, Cidade> Cidades { get; private set; }

        public Ferrovia()
        {
            Cidades = new Dictionary<string, Cidade>();
        }

        // Adiciona as rotas modeladas em forma de grafo usando hashtable. 
        public void AdicionarRota(string origem, string destino, double distancia)
        {
            Cidade cidadeOrigem;
            Cidade cidadeDestino;

            if (Cidades.ContainsKey(origem))
                cidadeOrigem = Cidades[origem];
            else
                cidadeOrigem = new Cidade(origem);

            if (Cidades.ContainsKey(destino))
                cidadeDestino = Cidades[destino];
            else
                cidadeDestino = new Cidade(destino);

            cidadeOrigem.AdicionarRota(cidadeDestino, distancia);
            Cidades[origem] = cidadeOrigem;
        }

        public bool CidadeExiste(string cidade)
        {
            return Cidades.ContainsKey(cidade);
        }

        public Cidade ObterCidade(string cidade)
        {
            return Cidades[cidade];
        }
    }
}
