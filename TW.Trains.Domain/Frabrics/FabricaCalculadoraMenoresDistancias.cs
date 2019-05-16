using System;
using TW.Trains.Domain.Models;
using TW.Trains.Domain.Services;

namespace TW.Trains.Domain.Frabrics
{
    public static class FabricaCalculadoraMenoresDistancias
    {
        public static ICalculadoraMenoresDistancias CriarCalculadoraMenoresDistancias(Ferrovia ferrovia)
        {
            return new CalculadoraMenoresDistancias(ferrovia);
        }
    }
}
