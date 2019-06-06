using System;
using System.Collections.Generic;

namespace TW.Trains.Domain.Models
{
    public class Cidade
    {
        public Cidade(string nome)
        {
            Nome = nome;
            Vizinhos = new Dictionary<string, Rota>();
        }

        public string Nome { get; private set; }
        public Dictionary<string, Rota> Vizinhos { get; private set; }

        public void AdicionarRota(Cidade cidadeDestino, double distancia)
        {
            Rota novaRota = new Rota(this, cidadeDestino, distancia);
            Vizinhos.Add(cidadeDestino.Nome, novaRota);
        }

        public bool RotaExiste(string cidadeDestino)
        {
            return Vizinhos.ContainsKey(cidadeDestino);
        }

        public Rota ObterRota(string destino)
        {
            return Vizinhos[destino];
        }
    }
}
