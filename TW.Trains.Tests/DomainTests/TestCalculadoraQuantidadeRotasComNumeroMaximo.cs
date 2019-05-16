using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.Trains.Domain.Frabrics;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Tests.DomainTests
{
    [TestClass]
    public class TestCalculadoraQuantidadeRotasComNumeroMaximo : TestsBase
    {
        [TestMethod]
        public void CalcularQuantidadeRotasComNumeroMaximo_CidadeOrigemNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroMaximo(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("F", "A", 1);

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularQuantidadeRotasComNumeroMaximo_CidadeDestinoNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroMaximo(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("A", "F", 1);

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularQuantidadeRotasComNumeroMaximo_CidadeExistem_DeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroMaximo(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("C", "C", 3);

            Assert.IsTrue(resultado == "2");
        }
    }
}
