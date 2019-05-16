using System;
using TW.Trains.Domain.Models;
using TW.Trains.Domain.Services;

namespace TW.Trains.Domain.Frabrics
{
    public static class FabricaCalculadoraQuantidadeRotas
    {
        public static ICalculadoraQuantidadeRotas CriarCalculadoraQuantidadeRotasComDistanciaMaxima(Ferrovia ferrovia)
        {
            return new CalculadoraQuantidadeRotasComDistanciaMaxima(ferrovia);
        }

        public static ICalculadoraQuantidadeRotas CriarCalculadoraQuantidadeRotasComNumeroExato(Ferrovia ferrovia)
        {
            return new CalculadoraQuantidadeRotasComNumeroExato(ferrovia);
        }

        public static ICalculadoraQuantidadeRotas CriarCalculadoraQuantidadeRotasComNumeroMaximo(Ferrovia ferrovia)
        {
            return new CalculadoraQuantidadeRotasComNumeroMaximo(ferrovia);
        }
    }
}
