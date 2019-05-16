using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.Trains.Domain.Frabrics;
using TW.Trains.Domain.Services;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Tests.DomainTests
{
    [TestClass]
    public class TestCalculadoraQuantidadeRotasComDistanciaMaxima : TestsBase
    {
        [TestMethod]
        public void CalcularQuantidadeRotasComDistanciaMaxima_CidadeOrigemNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComDistanciaMaxima(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("F", "A", 1);

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularQuantidadeRotasComDistanciaMaxima_CidadeDestinoNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComDistanciaMaxima(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("A", "F", 1);

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularQuantidadeRotasComDistanciaMaxima_CidadeExistem_DeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComDistanciaMaxima(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("C", "C", 30);

            Assert.IsTrue(resultado == "7");
        }
    }
}
