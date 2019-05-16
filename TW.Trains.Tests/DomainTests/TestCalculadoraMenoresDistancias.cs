using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.Trains.Domain.Frabrics;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Tests.DomainTests
{
    [TestClass]
    public class TestCalculadoraMenoresDistancias : TestsBase
    {
        [TestMethod]
        public void CalcularDistanciaDaMenorRotaParaViajar_CidadeOrigemNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraMenoresDistancias.CriarCalculadoraMenoresDistancias(ferrovia);

            var resultado = servico.CalcularDistanciaDaMenorRotaParaViajar("F", "A");

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularDistanciaDaMenorRotaParaViajar_CidadeDestinoNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraMenoresDistancias.CriarCalculadoraMenoresDistancias(ferrovia);

            var resultado = servico.CalcularDistanciaDaMenorRotaParaViajar("A", "F");

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularDistanciaDaMenorRotaParaViajar_CidadeExistem_DeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraMenoresDistancias.CriarCalculadoraMenoresDistancias(ferrovia);

            var resultado = servico.CalcularDistanciaDaMenorRotaParaViajar("A", "C");

            Assert.IsTrue(resultado == "9");
        }
    }
}
