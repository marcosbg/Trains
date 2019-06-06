using System;
namespace TW.Trains.Domain.Models
{
    public class Rota
    {
        public Rota(Cidade origem, Cidade destino, double distancia)
        {
            Origem = origem;
            Destino = destino;
            Distancia = distancia;
        }

        public Cidade Origem { get; private set; }
        public Cidade Destino { get; private set; }
        public double Distancia { get; private set; }
    }
}
