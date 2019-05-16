using System;
using TW.Trains.Domain.Frabrics;
using TW.Trains.Domain.Models;

namespace TW.Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            Ferrovia ferrovia = LerDadosFerrovia();

            var servicoCalculadoraDistancia = FabricaCalculadoraDistancia.CriarCalculadoraDistancias(ferrovia);
            var servicoCalculadoraMenoresDistancias = FabricaCalculadoraMenoresDistancias.CriarCalculadoraMenoresDistancias(ferrovia);
            var servicoCalculadoraQuantidadeRotasComNumeroMaximo = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroMaximo(ferrovia);
            var servicoCalculadoraQuantidadeRotasComNumeroExato = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroExato(ferrovia);
            var servicoCalculadoraQuantidadeRotasComDistanciaMaxima = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComDistanciaMaxima(ferrovia);

            ImprimirResultado("#1", servicoCalculadoraDistancia.CalcularDistanciaRotaEntreCidades(
                cidades: new string[] { "A", "B", "C" }));

            ImprimirResultado("#2", servicoCalculadoraDistancia.CalcularDistanciaRotaEntreCidades(
                cidades: new string[] { "A", "D" }));

            ImprimirResultado("#3", servicoCalculadoraDistancia.CalcularDistanciaRotaEntreCidades(
                cidades: new string[] { "A", "D", "C" }));

            ImprimirResultado("#4", servicoCalculadoraDistancia.CalcularDistanciaRotaEntreCidades(
                cidades: new string[] { "A", "E", "B", "C", "D" }));

            ImprimirResultado("#5", servicoCalculadoraDistancia.CalcularDistanciaRotaEntreCidades(
                cidades: new string[] { "A", "E", "D" }));               

            ImprimirResultado("#6", servicoCalculadoraQuantidadeRotasComNumeroMaximo.CalcularQuantidadeRotas("C", "C", 3));

            ImprimirResultado("#7", servicoCalculadoraQuantidadeRotasComNumeroExato.CalcularQuantidadeRotas("A", "C", 4));

            ImprimirResultado("#8", servicoCalculadoraMenoresDistancias.CalcularDistanciaDaMenorRotaParaViajar("A", "C"));

            ImprimirResultado("#9", servicoCalculadoraMenoresDistancias.CalcularDistanciaDaMenorRotaParaViajar("B", "B"));

            ImprimirResultado("#10", servicoCalculadoraQuantidadeRotasComDistanciaMaxima.CalcularQuantidadeRotas("C", "C", 30));
        }

        static Ferrovia LerDadosFerrovia()
        {
            Ferrovia ferrovia = new Ferrovia();
            var rotas = Console.ReadLine().Split(",");

            for (int i = 0; i < rotas.Length; i++)
            {
                var rota = rotas[i].Trim();
                var cidadeOrigem = rota.Substring(0, 1);
                var cidadeDestino = rota.Substring(1, 1);
                var distancia = double.Parse(rota.Substring(2, 1));

                ferrovia.AdicionarRota(cidadeOrigem, cidadeDestino, distancia);
            }

            return ferrovia;
        }

        static void ImprimirResultado(string numeroTeste, string resultado)
        {
            Console.WriteLine($"Output {numeroTeste}: {resultado}");
        }
    }
}
