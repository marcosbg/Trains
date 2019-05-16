using System;
using TW.Trains.Domain.Models;
using TW.Trains.Domain.Services;

namespace TW.Trains.Domain.Frabrics
{
    public static class FabricaCalculadoraDistancia
    {
        public static ICalculadoraDistancias CriarCalculadoraDistancias(Ferrovia ferrovia)
        {
            return new CalculadoraDistancias(ferrovia);
        }
    }
}
